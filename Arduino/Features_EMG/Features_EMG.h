#ifdef ARDUINO
#if ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h" /* This is where the standard Arduino code lies */
#endif
#else
#include <stdlib.h>
#include <stdio.h>
#include <math.h>
#endif

#define NEMAV_min 0.0770
#define NEMAV_max 0.7238
#define NMAV_min 0.0188
#define NMAV_max 0.6556
#define NRMS_min 0.0243
#define NRMS_max 0.8244
#define NAAC_min 0.0018
#define NAAC_max 0.1184
#define NDASDV_min 0.0030
#define NDASDV_max 0.1505
#define NMMAV_min 0.0144
#define NMMAV_max 0.5036
#define NMMAV2_min 0.0096
#define NMMAV2_max 0.4052
#define NVAR_min 0.0005892754876608302
#define NVAR_max 0.6799


class Features_EMG {
public:
	Features_EMG(double* signal, int L, int fs);
	~Features_EMG(void);
	double length_seconds();
	double EMAV();
	double MAV();
	double RMS();
	double AAC();
	double DASDV();
	double MMAV();
	double MMAV2();
	double VAR();
	double NEMAV();
	double NMAV();
	double NRMS();
	double NAAC();
	double NDASDV();
	double NMMAV();
	double NMMAV2();
	double NVAR();
private:
	double* _signal;
	int _L;
	int _fs;
};


