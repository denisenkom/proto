// sendmessage.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <atlbase.h>
#include <atlwin.h>

class A {
	A() {int x = 5;};
public:
	static A& getInstance() {static A a; return a;}
};

class Win : public ATL::CWindowImpl<Win, CWindow, CFrameWinTraits>
{
public:
	BEGIN_MSG_MAP(Win1)
		MESSAGE_HANDLER(WM_USER, OnUser);
	END_MSG_MAP()

	LRESULT OnUser(UINT, WPARAM y, LPARAM, BOOL&)
	{
		std::cout << "OnUser y=" << y << std::endl;
		return 555;
	}
} w1, w2;

HANDLE sem1;

DWORD WINAPI thrd2(LPVOID)
{
	w2.Create(NULL);
	::ReleaseSemaphore(sem1, 1, 0);
	w2.ShowWindow(SW_SHOW);
	MSG msg;
	SendMessage(w1, WM_USER, 1, 0);
	//while (GetMessage(&msg,0,0,0)) {DispatchMessage(&msg);}
	return 0;
}

int main(int argc, char* argv[])
{
	w1.Create(NULL);
	w1.ShowWindow(SW_SHOW);
	sem1 = ::CreateSemaphore(0, 0, 1, "semafore1");
	CreateThread(0, 0, &thrd2, 0, 0, 0);
	::WaitForSingleObject(sem1, INFINITE);
	SendMessage(w2, WM_USER, 0, 0);
	MSG msg;
	//while (GetMessage(&msg,0,0,0)) {DispatchMessage(&msg);}
	return 0;
}
