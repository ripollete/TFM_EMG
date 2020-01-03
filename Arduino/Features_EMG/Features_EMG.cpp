#include "Features_EMG.h"



Features_EMG::Features_EMG(double* signal, int L, int fs)
{
	this->_signal = signal;
	this->_L = L;
	this->_fs = fs;
}

Features_EMG::~Features_EMG(void)
{
	// Destructor
}

double Features_EMG::length_seconds()
{
	return (double)_L / (double)_fs;
}

double Features_EMG::EMAV()
{
	double Y = 0;
	double limit1 = 0.2 * _L;
	double limit2 = 0.8 * _L;
	for (int i = 0; i < _L; i++)
	{
		if ((i + 1) >= limit1 && (i + 1) <= limit2)
		{
			Y = Y + pow(fabs(_signal[i]), 0.75);
		}
		else
		{
			Y = Y + pow(fabs(_signal[i]), 0.5);
			
		}

	}
	return Y / _L;
}

double Features_EMG::MAV()
{
	double Y = 0;
	for (int i = 0; i < _L; i++)
		Y = Y + fabs(_signal[i]);
	return Y / _L;
}

double Features_EMG::RMS()
{
	double Y = 0;
	for (int i = 0; i < _L; i++)
		Y = Y + (_signal[i] * _signal[i]);
	return sqrt(Y / _L);
}

double Features_EMG::AAC()
{
	double Y = 0;
	for (int i = 0; i < _L - 1; i++)
		Y = Y + fabs(_signal[i + 1] - _signal[i]);
	return Y / _L;
}

double Features_EMG::DASDV()
{
	double Y = 0;
	for (int i = 0; i < _L - 1; i++)
		Y = Y + pow((_signal[i + 1] - _signal[i]), 2);
	return sqrt(Y / (_L - 1));
}

double Features_EMG::MMAV()
{
	double Y = 0;
	double limit1 = 0.25 * _L;
	double limit2 = 0.75 * _L;
	for (int i = 0; i < _L; i++)
		if ((i + 1) >= limit1 && (i + 1) <= limit2) //-1 because array start with zero
			Y = Y + fabs(_signal[i]);
		else
			Y = Y + fabs(_signal[i]) * .5;
	return Y / _L;
}

double Features_EMG::MMAV2()
{
	double Y = 0;
	double limit1 = 0.25 * _L;
	double limit2 = 0.75 * _L;
	for (int i = 0; i < _L; i++)
		if ((i + 1) >= limit1 && (i + 1) <= limit2)
		{
			Y = Y + fabs(_signal[i]);
		}
		else if ((i + 1) < limit1)
		{
			Y = Y + fabs(_signal[i]) * ((4.0 * (i + 1.0)) / _L);
		}
		else
		{
			Y = Y + fabs(_signal[i]) * ((4.0 * (i + 1.0 - _L)) / _L);
		}
	return Y / _L;
}

double Features_EMG::VAR()
{
	double Y = 0;
	for (int i = 0; i < _L; i++)
		Y = Y + _signal[i] * _signal[i];
	return Y / (_L - 1.0);
}

double Features_EMG::NEMAV()
{
	return (EMAV() - NEMAV_min) / (NEMAV_max - NEMAV_min);
}
double Features_EMG::NMAV()
{
	return (MAV() - NMAV_min) / (NMAV_max - NMAV_min);
}
double Features_EMG::NRMS()
{
	return (RMS() - NRMS_min) / (NRMS_max - NRMS_min);
}
double Features_EMG::NAAC()
{
	return (AAC() - NAAC_min) / (NAAC_max - NAAC_min);
}
double Features_EMG::NDASDV()
{
	return (DASDV() - NDASDV_min) / (NDASDV_max - NDASDV_min);
}
double Features_EMG::NMMAV()
{
	return (MMAV() - NMMAV_min) / (NMMAV_max - NMMAV_min);
}
double Features_EMG::NMMAV2()
{
	return (MMAV2() - NMMAV2_min) / (NMMAV2_max - NMMAV2_min);
}
double Features_EMG::NVAR()
{
	return (VAR() - NVAR_min) / (NVAR_max - NVAR_min);
}