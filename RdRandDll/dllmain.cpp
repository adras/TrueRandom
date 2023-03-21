// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include "..\rdrand\rdrand.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

extern int Rdrand_16(uint16_t* x, int retry)
{
    return rdrand_16(x, retry);
}

int Rdrand_get_bytes(unsigned int n, unsigned char* dest)
{
    return rdrand_get_bytes(n, dest);
}

