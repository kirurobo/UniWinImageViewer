// LibUniWinC.cpp

#include "pch.h"
#include "libuniwinc.h"


static HWND hTargetWnd_ = NULL;
static WINDOWINFO originalWindowInfo;
static WINDOWPLACEMENT originalWindowPlacement;
static SIZE originaiBorderSize;
static POINT ptVirtualScreen;
static SIZE szVirtualScreen;
static int nPrimaryMonitorHeight;
static BOOL bIsTransparent = FALSE;
static BOOL bIsBorderless= FALSE;
static BOOL bIsTopmost = FALSE;
static BOOL bIsClickThrough = FALSE;
static COLORREF dwKeyColor = 0x00000000;		// AABBGGRR
static TransparentType nTransparentType = TransparentType::Alpha;
static TransparentType nCurrentTransparentType = TransparentType::Alpha;


void attachWindow(const HWND hWnd);
void detachWindow();
void refreshWindow();
void updateScreenSize();


/// <summary>
/// ���ɃE�B���h�E���I���ς݂Ȃ�A���̏�Ԃɖ߂��đI��������
/// </summary>
void detachWindow()
{
	if (hTargetWnd_) {
		SetTransparent(false);
		
		SetWindowLong(hTargetWnd_, GWL_STYLE, originalWindowInfo.dwStyle);
		SetWindowLong(hTargetWnd_, GWL_EXSTYLE, originalWindowInfo.dwExStyle);

		SetWindowPlacement(hTargetWnd_, &originalWindowPlacement);

		refreshWindow();
	}
	hTargetWnd_ = NULL;
}

/// <summary>
/// �w��n���h���̃E�B���h�E������g���悤�ɂ���
/// </summary>
/// <param name="hWnd"></param>
void attachWindow(const HWND hWnd) {
	// �I���ς݃E�B���h�E���قȂ���̂ł���΁A���ɖ߂�
	if (hTargetWnd_ != hWnd) {
		detachWindow();
	}

	// �Ƃ肠�������̃^�C�~���O�ŉ�ʃT�C�Y���X�V
	updateScreenSize();

	// �E�B���h�E��I��
	hTargetWnd_ = hWnd;

	if (hWnd) {
		// ������Ԃ��L�����Ă���
		GetWindowInfo(hWnd, &originalWindowInfo);
		GetWindowPlacement(hWnd, &originalWindowPlacement);


		// ���ɐݒ肪����ΓK�p
		SetTransparent(bIsTransparent);
		SetBorderless(bIsBorderless);
		SetTopmost(bIsTopmost);
		SetClickThrough(bIsClickThrough);
	}
}

/// <summary>
/// �I�[�i�[�E�B���h�E�n���h����T���ۂ̃R�[���o�b�N
/// </summary>
/// <param name="hWnd"></param>
/// <param name="lParam"></param>
/// <returns></returns>
BOOL CALLBACK findOwnerWindowProc(const HWND hWnd, const LPARAM lParam)
{
	DWORD currentPid = (DWORD)lParam;
	DWORD pid;
	GetWindowThreadProcessId(hWnd, &pid);

	// �v���Z�XID����v����Ύ����̃E�B���h�E�Ƃ���
	if (pid == currentPid) {

		// �I�[�i�[�E�B���h�E��T��
		// Unity�G�f�B�^���Ɩ{�̂��I�΂�ēƗ�Game�r���[���I�΂�Ȃ��c
		HWND hOwner = GetWindow(hWnd, GW_OWNER);
		if (hOwner) {
			// ����΃I�[�i�[��I��
			attachWindow(hOwner);
		}
		else {
			// �I�[�i�[��������΂��̃E�B���h�E��I��
			attachWindow(hWnd);
		}
		return FALSE;

		//// �����v���Z�XID�ł��A�\������Ă���E�B���h�E�݂̂�I��
		//LONG style = GetWindowLong(hWnd, GWL_STYLE);
		//if (style & WS_VISIBLE) {
		//	hTargetWnd_ = hWnd;
		//	return FALSE;
		//}
	}

	return TRUE;
}

void enableTransparentByDWM()
{
	if (!hTargetWnd_) return;

	// �S�ʂ�Glass�ɂ���
	MARGINS margins = { -1 };
	DwmExtendFrameIntoClientArea(hTargetWnd_, &margins);
}

void disableTransparentByDWM()
{
	if (!hTargetWnd_) return;

	// �g�̂�Glass�ɂ���
	//	�� �{���̃E�B���h�E�����炩�͈͎̔w���Glass�ɂ��Ă����ꍇ�́A�c�O�Ȃ���\�����߂�܂���
	MARGINS margins = { 0, 0, 0, 0 };
	DwmExtendFrameIntoClientArea(hTargetWnd_, &margins);
}

/// <summary>
/// SetLayeredWindowsAttributes �ɂ���Ďw��F�𓧉߂�����
/// </summary>
void enableTransparentBySetLayered()
{
	if (!hTargetWnd_) return;

	LONG exstyle = GetWindowLong(hTargetWnd_, GWL_EXSTYLE);
	exstyle |= WS_EX_LAYERED;
	SetWindowLong(hTargetWnd_, GWL_EXSTYLE, exstyle);
	SetLayeredWindowAttributes(hTargetWnd_, dwKeyColor, 0xFF, LWA_COLORKEY);
}

/// <summary>
/// SetLayeredWindowsAttributes �ɂ��w��F���߂�����
/// </summary>
void disableTransparentBySetLayered()
{
	COLORREF cref = { 0 };
	SetLayeredWindowAttributes(hTargetWnd_, cref, 0xFF, LWA_ALPHA);

	LONG exstyle = originalWindowInfo.dwExStyle;
	//exstyle &= ~WinApi.WS_EX_LAYERED;
	SetWindowLong(hTargetWnd_, GWL_EXSTYLE, exstyle);
}

/// <summary>
/// �g���������ۂɕ`��T�C�Y������Ȃ��Ȃ邱�ƂɑΉ����邽�߁A�E�B���h�E���������T�C�Y���čX�V
/// </summary>
void refreshWindow() {
	if (!hTargetWnd_) return;

	if (IsZoomed(hTargetWnd_)) {
		// �ő剻����Ă����ꍇ�́A�E�B���h�E�T�C�Y�ύX�̑���Ɉ�x�ŏ������čēx�ő剻
		ShowWindow(hTargetWnd_, SW_MINIMIZE);
		ShowWindow(hTargetWnd_, SW_MAXIMIZE);
	}
	else if (IsIconic(hTargetWnd_)) {
		// �ŏ�������Ă����ꍇ�́A���ɕ\�������Ƃ��ɂ������񂳂����̂Ƃ��āA�������Ȃ�
	}
	else if (IsWindowVisible(hTargetWnd_)) {
		// �ʏ�̃E�B���h�E�������ꍇ�́A�E�B���h�E�T�C�Y��1px�ς��邱�Ƃōĕ`��

		// ���݂̃E�B���h�E�T�C�Y���擾
		RECT rect;
		GetWindowRect(hTargetWnd_, &rect);

		// 1px�������L���āA���T�C�Y�C�x���g�������I�ɋN����
		SetWindowPos(
			hTargetWnd_,
			NULL,
			0, 0, (rect.right - rect.left + 1), (rect.bottom - rect.top + 1),
			SWP_NOMOVE | SWP_NOZORDER | SWP_FRAMECHANGED | SWP_NOOWNERZORDER | SWP_NOACTIVATE | SWP_ASYNCWINDOWPOS
		);

		// ���̃T�C�Y�ɖ߂��B���̎������T�C�Y�C�x���g�͔�������͂�
		SetWindowPos(
			hTargetWnd_,
			NULL,
			0, 0, (rect.right - rect.left), (rect.bottom - rect.top),
			SWP_NOMOVE | SWP_NOZORDER | SWP_FRAMECHANGED | SWP_NOOWNERZORDER | SWP_NOACTIVATE | SWP_ASYNCWINDOWPOS
		);

		ShowWindow(hTargetWnd_, SW_SHOW);
	}
}

BOOL compareRect(const RECT rcA, const RECT rcB) {
	return ((rcA.left == rcB.left) && (rcA.right == rcB.right) && (rcA.top == rcB.top) && (rcA.bottom == rcB.bottom));
}

/// <summary>
/// ���݂̉�ʃT�C�Y���擾
/// </summary>
/// <returns></returns>
void updateScreenSize() {
	ptVirtualScreen.x = GetSystemMetrics(SM_XVIRTUALSCREEN);
	ptVirtualScreen.y = GetSystemMetrics(SM_YVIRTUALSCREEN);
	szVirtualScreen.cx = GetSystemMetrics(SM_CXVIRTUALSCREEN);
	szVirtualScreen.cy = GetSystemMetrics(SM_CYVIRTUALSCREEN);
	nPrimaryMonitorHeight = GetSystemMetrics(SM_CYSCREEN);
}

/// <summary>
/// Cocoa�Ɠ��l��Y���W�ɕϊ�
/// ���O�Ƀv���C�}���[���j�^�[�̍������擾�ł��Ă��邱�ƂƂ���
/// </summary>
/// <param name="y"></param>
/// <returns></returns>
LONG calcFlippedY(LONG y) {
	return (nPrimaryMonitorHeight - y);
}

// Windows only

/// <summary>
/// ���ݑI������Ă���E�B���h�E�n���h�����擾
/// </summary>
/// <returns></returns>
HWND UNIWINC_API GetWindowHandle() {
	return hTargetWnd_;
}

/// <summary>
/// �����̃v���Z�XID���擾
/// </summary>
/// <returns></returns>
DWORD UNIWINC_API GetMyProcessId() {
	return GetCurrentProcessId();
}



// Public functions

/// <summary>
/// ���p�\�ȏ�ԂȂ�true��Ԃ�
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API IsActive() {
	if (hTargetWnd_ && IsWindow(hTargetWnd_)) {
		return TRUE;
	}
	return FALSE;
}

/// <summary>
/// ���߂ɂ��Ă��邩�ۂ���Ԃ�
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API IsTransparent() {
	return bIsTransparent;
}

/// <summary>
/// �g���������Ă��邩�ۂ���Ԃ�
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API IsBorderless() {
	return bIsBorderless;
}

/// <summary>
/// �őO�ʂɂ��Ă��邩�ۂ���Ԃ�
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API IsTopmost() {
	return bIsTopmost;
}

/// <summary>
/// �ő剻���Ă��邩�ۂ���Ԃ�
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API IsMaximized() {
	return (hTargetWnd_ && IsZoomed(hTargetWnd_));
}

/// <summary>
/// �E�B���h�E�����ɖ߂��đΏۂ������
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API DetachWindow() {
	detachWindow();
	return true;
}

/// <summary>
/// �����̃E�B���h�E��T���đI���i�I�[�i�[�Ɠ����j
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API AttachMyWindow() {
	return AttachMyOwnerWindow();
}

/// <summary>
/// ���݂̃v���Z�XID�����I�[�i�[�E�B���h�E��T���đI��
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API AttachMyOwnerWindow() {
	DWORD currentPid = GetCurrentProcessId();
	return EnumWindows(findOwnerWindowProc, (LPARAM)currentPid);
}

/// <summary>
/// ���݃A�N�e�B�u�A���v���Z�XID����v����E�B���h�E��I��
/// </summary>
/// <returns></returns>
BOOL UNIWINC_API AttachMyActiveWindow() {
	DWORD currentPid = GetCurrentProcessId();
	HWND hWnd = GetActiveWindow();
	DWORD pid;

	GetWindowThreadProcessId(hWnd, &pid);
	if (pid == currentPid) {
		attachWindow(hWnd);
		return TRUE;
	}
	return FALSE;
}

/// <summary>
/// ���������@�̑I����ύX
/// </summary>
/// <param name="type"></param>
/// <returns></returns>
void UNIWINC_API SetTransparentType(const TransparentType type) {
	if (bIsTransparent) {
		// ��������Ԃł���΁A��x�������Ă���ݒ�
		SetTransparent(FALSE);
		nTransparentType = type;
		SetTransparent(TRUE);
	}
	else {
		// ��������ԂłȂ���΁A���̂܂ܐݒ�
		nTransparentType = type;
	}
}

/// <summary>
/// �P�F���ߎ��ɓ��߂Ƃ���F���w��
/// </summary>
/// <param name="color">���߂���F</param>
/// <returns></returns>
void UNIWINC_API SetKeyColor(const COLORREF color) {
	if (bIsTransparent && (nTransparentType == TransparentType::ColorKey)) {
		// ��������Ԃł���΁A��x�������Ă���ݒ�
		SetTransparent(FALSE);
		dwKeyColor = color;
		SetTransparent(TRUE);
	}
	else {
		// ��������ԂłȂ���΁A���̂܂ܐݒ�
		dwKeyColor = color;
	}
}

/// <summary>
/// ���߂���јg������ݒ�^����
/// </summary>
/// <param name="bTransparent"></param>
/// <returns></returns>
void UNIWINC_API SetTransparent(const BOOL bTransparent) {
	if (hTargetWnd_) {
		if (bTransparent) {
			switch (nTransparentType)
			{
			case Alpha:
				enableTransparentByDWM();
				break;
			case ColorKey:
				enableTransparentBySetLayered();
				break;
			default:
				break;
			}
		}
		else {
			switch (nCurrentTransparentType)
			{
			case Alpha:
				disableTransparentByDWM();
				break;
			case ColorKey:
				disableTransparentBySetLayered();
				break;
			default:
				break;
			}
		}

		// �߂����@�����߂邽�߁A���������ύX���ꂽ���̃^�C�v���L��
		nCurrentTransparentType = nTransparentType;
	}

	// ��������Ԃ��L��
	bIsTransparent = bTransparent;
}


/// <summary>
/// �E�B���h�E�g��L���^�����ɂ���
/// </summary>
/// <param name="bBorderless"></param>
void UNIWINC_API SetBorderless(const BOOL bBorderless) {
	if (hTargetWnd_) {
		int newW, newH, newX, newY;
		RECT rcWin, rcCli;
		GetWindowRect(hTargetWnd_, &rcWin);
		GetClientRect(hTargetWnd_, &rcCli);

		int w = rcWin.right - rcWin.left;
		int h = rcWin.bottom - rcWin.top;

		int bZoomed = IsZoomed(hTargetWnd_);
		int bIconic = IsIconic(hTargetWnd_);

		// �ő剻����Ă�����A��x�ő剻�͉���
		if (bZoomed) {
			ShowWindow(hTargetWnd_, SW_NORMAL);
		}

		if (bBorderless) {
			// �g�����E�B���h�E�ɂ���
			LONG currentWS = (WS_VISIBLE | WS_POPUP);
			SetWindowLong(hTargetWnd_, GWL_STYLE, currentWS);

			newW = rcCli.right - rcCli.left;
			newH = rcCli.bottom - rcCli.top;

			int bw = (w - newW) / 2;	// �g�̕Б��� [px]
			newX = rcWin.left + bw;
			newY = rcWin.top + ((h - newH) - bw);	// �{���͘g�̉��������ƍ��E�̕��������ۏ؂͂Ȃ����A�Ƃ肠���������Ƃ݂Ȃ��Ă���

		}
		else {
			// �E�B���h�E�X�^�C����߂�
			SetWindowLong(hTargetWnd_, GWL_STYLE, originalWindowInfo.dwStyle);

			int dx = (originalWindowInfo.rcWindow.right - originalWindowInfo.rcWindow.left) - (originalWindowInfo.rcClient.right - originalWindowInfo.rcClient.left);
			int dy = (originalWindowInfo.rcWindow.bottom - originalWindowInfo.rcWindow.top) - (originalWindowInfo.rcClient.bottom - originalWindowInfo.rcClient.top);
			int bw = dx / 2;	// �g�̕Б��� [px]

			newW = rcCli.right - rcCli.left + dx;
			newH = rcCli.bottom- rcCli.top + dy;

			newX = rcWin.left - bw;
			newY = rcWin.top - (dy - bw);	// �{���͘g�̉��������ƍ��E�̕��������ۏ؂͂Ȃ����A�Ƃ肠���������Ƃ݂Ȃ��Ă���
		}

		// �E�B���h�E�T�C�Y���ω����Ȃ����A�ő剻��ŏ�����ԂȂ�W���̃T�C�Y�X�V
		if (bZoomed) {
			// �ő剻����Ă�����A�����ōēx�ő剻
			ShowWindow(hTargetWnd_, SW_MAXIMIZE);
		} else if (bIconic) {
			// �ŏ�������Ă�����A���ɕ\�������Ƃ��̍ĕ`������҂��āA�������Ȃ�
		} else if (newW == w && newH == h) {
			// �E�B���h�E�ĕ`��
			refreshWindow();
		}
		else
		{
			// �N���C�A���g�̈�T�C�Y���ێ�����悤�T�C�Y�ƈʒu�𒲐�
			SetWindowPos(
				hTargetWnd_,
				NULL,
				newX, newY, newW, newH,
				SWP_NOZORDER | SWP_FRAMECHANGED | SWP_NOOWNERZORDER | SWP_NOACTIVATE | SWP_ASYNCWINDOWPOS
			);

			ShowWindow(hTargetWnd_, SW_SHOW);
		}
	}

	// �g���������L��
	bIsBorderless = bBorderless;
}

/// <summary>
/// �őO�ʉ��^����
/// </summary>
/// <param name="bTopmost"></param>
/// <returns></returns>
void UNIWINC_API SetTopmost(const BOOL bTopmost) {
	if (hTargetWnd_) {
		SetWindowPos(
			hTargetWnd_,
			(bTopmost ? HWND_TOPMOST : HWND_NOTOPMOST),
			0, 0, 0, 0,
			SWP_NOSIZE | SWP_NOMOVE | SWP_NOOWNERZORDER | SWP_NOACTIVATE | SWP_ASYNCWINDOWPOS // | SWP_FRAMECHANGED
		);
	}

	bIsTopmost = bTopmost;
}

/// <summary>
/// �ő剻�^����
/// </summary>
/// <param name="bZoomed"></param>
/// <returns></returns>
void UNIWINC_API SetMaximized(const BOOL bZoomed) {
	if (hTargetWnd_) {
		if (bZoomed) {
			ShowWindow(hTargetWnd_, SW_MAXIMIZE);
		}
		else
		{
			ShowWindow(hTargetWnd_, SW_NORMAL);
		}
	}
}

void UNIWINC_API SetClickThrough(const BOOL bTransparent) {
	if (hTargetWnd_) {
		if (bTransparent) {
			LONG exstyle = GetWindowLong(hTargetWnd_, GWL_EXSTYLE);
			exstyle |= WS_EX_TRANSPARENT;
			exstyle |= WS_EX_LAYERED;
			SetWindowLong(hTargetWnd_, GWL_EXSTYLE, exstyle);
		}
		else
		{
			LONG exstyle = GetWindowLong(hTargetWnd_, GWL_EXSTYLE);
			exstyle &= ~WS_EX_TRANSPARENT;
			if (!bIsTransparent && !(originalWindowInfo.dwExStyle & WS_EX_LAYERED)) {
				exstyle &= ~WS_EX_LAYERED;
			}
			SetWindowLong(hTargetWnd_, GWL_EXSTYLE, exstyle);
		}
	}
	bIsClickThrough = bTransparent;
}

/// <summary>
/// �E�B���h�E���W��ݒ�
/// </summary>
/// <param name="x">�E�B���h�E���[���W [px]</param>
/// <param name="y">�v���C�}���[��ʉ��[�����_�Ƃ��A�オ����Y���W [px]</param>
/// <returns>��������� true</returns>
BOOL UNIWINC_API SetPosition(const float x, const float y) {
	if (hTargetWnd_ == NULL) return FALSE;

	// ���݂̃E�B���h�E�ʒu�ƃT�C�Y���擾
	RECT rect;
	GetWindowRect(hTargetWnd_, &rect);

	// ������ y ��Cocoa�����̍��W�n�ŃE�B���h�E�����Ȃ̂ŁA�ϊ�
	int newY = (nPrimaryMonitorHeight - (int)y) - (rect.bottom - rect.top);

	return SetWindowPos(
		hTargetWnd_, NULL,
		(int)x, (int)newY,
		0, 0,
		SWP_NOACTIVATE | SWP_NOOWNERZORDER | SWP_NOSIZE | SWP_NOZORDER | SWP_ASYNCWINDOWPOS
		);
}

/// <summary>
/// �E�B���h�E���W���擾
/// </summary>
/// <param name="x">�E�B���h�E���[���W [px]</param>
/// <param name="y">�v���C�}���[��ʉ��[�����_�Ƃ��A�オ����Y���W [px]</param>
/// <returns>��������� true</returns>
BOOL UNIWINC_API GetPosition(float* x, float* y) {
	*x = 0;
	*y = 0;

	if (hTargetWnd_ == NULL) return FALSE;

	RECT rect;
	if (GetWindowRect(hTargetWnd_, &rect)) {
		*x = (float)rect.left;
		*y = (float)(nPrimaryMonitorHeight - rect.bottom);	// ������Ƃ���
		return TRUE;
	}
	return FALSE;
}

/// <summary>
/// �E�B���h�E�T�C�Y��ݒ�
/// </summary>
/// <param name="width">�� [px]</param>
/// <param name="height">���� [px]</param>
/// <returns>��������� true</returns>
BOOL UNIWINC_API SetSize(const float width, const float height) {
	if (hTargetWnd_ == NULL) return FALSE;

	// ���݂̃E�B���h�E�ʒu�ƃT�C�Y���擾
	RECT rect;
	GetWindowRect(hTargetWnd_, &rect);

	// �������_�Ƃ��邽�߂ɒ��������A�V�KY���W
	int newY = rect.bottom - (int)height;

	return SetWindowPos(
		hTargetWnd_, NULL,
		rect.left, newY,
		(int)width, (int)height,
		SWP_NOACTIVATE | SWP_NOOWNERZORDER | SWP_NOZORDER | SWP_FRAMECHANGED | SWP_ASYNCWINDOWPOS
	);
}


/// <summary>
/// �E�B���h�E�T�C�Y���擾
/// </summary>
/// <param name="width">�� [px]</param>
/// <param name="height">���� [px]</param>
/// <returns>��������� true</returns>
BOOL  UNIWINC_API GetSize(float* width, float* height) {
	*width = 0;
	*height = 0;

	if (hTargetWnd_ == NULL) return FALSE;

	RECT rect;
	if (GetWindowRect(hTargetWnd_, &rect)) {
		*width = (float)(rect.right - rect.left);
		*height = (float)(rect.bottom - rect.top);
		return TRUE;
	}
	return FALSE;
}

/// <summary>
/// �}�E�X�J�[�\�����W���擾
/// </summary>
/// <param name="x">�E�B���h�E���[���W [px]</param>
/// <param name="y">�v���C�}���[��ʉ��[�����_�Ƃ��A�オ����Y���W [px]</param>
/// <returns>��������� true</returns>
BOOL UNIWINC_API GetCursorPosition(float* x, float* y) {
	*x = 0;
	*y = 0;

	POINT pos;
	if (GetCursorPos(&pos)) {
		*x = (float)pos.x;
		*y = (float)(nPrimaryMonitorHeight - pos.y - 1);	// ������Ƃ���
		return TRUE;
	}
	return FALSE;

}

/// <summary>
/// �}�E�X�J�[�\�����W��ݒ�
/// </summary>
/// <param name="x">�E�B���h�E���[���W [px]</param>
/// <param name="y">�v���C�}���[��ʉ��[�����_�Ƃ��A�オ����Y���W [px]</param>
/// <returns>��������� true</returns>
BOOL UNIWINC_API SetCursorPosition(const float x, const float y) {
	POINT pos;

	pos.x = (int)x;
	pos.y = nPrimaryMonitorHeight - (int)y - 1;

	return SetCursorPos(pos.x, pos.y);
}
