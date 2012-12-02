This is a 32-bit version of Encrypt.DLL written using Microsoft Visual Studio.


User files are:
The msencrypt.lib file used to link with the DLL. 
The msencrypt.dll file contains the encryption code.
The msencrypt.h file is a C/C++ header file for the library.

The single user function in the library is as follows:

int Encrypt(const char* Password, const char* Seed, char* EncryptedPassword);

	Password is a pointer to the password as entered by the user (8 ASCII
		characters).

	Seed is a pointer to the seed returned by the meter (16 characters in 
		the set {'0' - '9', 'A' - 'F'}).

	EncryptedPassword is the output result of the encryption in the 
		correct form for sending to the meter (16 characters in the
		set {'0' - '9', 'A' - 'F'} + terminating NULL character). This 
		should be a pointer to a 17 character buffer.

Note that it is not necessary for the input values to be NULL terminated, and
the output value (EncryptedPassword) will always be NULL terminated.

The return value is TRUE (non-zero) on success and zero on failure, although 
in this version all variations of password and seed are valid input,
therefore the function will always return TRUE.

