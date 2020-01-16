#include <compat/deprecated.h>
#include <FlexiTimer2.h>
#include <Features_EMG.h>

// All definitions
#define NUMCHANNELS 1
#define SAMPLES 150
#define SAMPFREQ 1024                     // ADC sampling rate 1024
#define TIMER2VAL (1024/(SAMPFREQ))       // Set 1024Hz sampling frequency
#define length(x) (sizeof(x)/sizeof(x[0]))
#define LED1 2
#define LED2 3
const double Coeffs[9][5] = {{-55.8,-50.929,113.14,-59.205,1.9511},
{-75.108,-46.645,134.14,-57.702,2.2369},
{-59.402,-48.104,116.66,-57.468,1.8863},
{-62.18,-44.898,110.6,-47.566,1.9991},
{-77.386,-45.448,140.99,-60.533,2.0675},
{-79.672,-54.29,155.14,-75.31,2.2665},
{-82.112,-51.816,152.75,-66.436,2.13},
{-77.623,-44.576,140.64,-60.739,2.0248},
{-73.872,-50.028,139.29,-61.479,1.9156}}; // 2 5 6 7

volatile double Buf[SAMPLES] = {0};  //The transmission packet
double BufCalc[SAMPLES] = {0};
volatile uint8_t pos_buf = 0;
volatile int a = 0;
volatile int contador = 0;
volatile unsigned int ADC_Value = 0;	  //ADC current value
volatile int ADC_Value_aux = 0;

unsigned int sampling_period_us;
unsigned long microseconds;

Features_EMG F_EMG(BufCalc, SAMPLES, SAMPFREQ);

//~~~~~~~~~~
// Functions
//~~~~~~~~~~


/****************************************************/
/*  Function name: setup                            */
/*  Parameters                                      */
/*    Input   :  No	                            */
/*    Output  :  No                                 */
/*    Action: Initializes all peripherals           */
/****************************************************/
void setup() {

  // Serial Port
  Serial.begin(115200);
  
  pinMode(LED1, OUTPUT);  //Setup LED1 direction
  pinMode(LED2, OUTPUT);  //Setup LED1 direction
  digitalWrite(LED1,LOW); //Setup LED1 state
  digitalWrite(LED2,LOW); //Setup LED1 state
  
  noInterrupts();  // Disable all interrupts before initialization

  // Timer2
  FlexiTimer2::set(TIMER2VAL, Timer2_Overflow_ISR);
  FlexiTimer2::start();

  interrupts();  // Enable all interrupts after initialization has been completed
}


/****************************************************/
/*  Function name: Timer2_Overflow_ISR              */
/*  Parameters                                      */
/*    Input   :  No	                            */
/*    Output  :  No                                 */
/*    Action: Determines ADC sampling frequency.    */
/****************************************************/
void Timer2_Overflow_ISR()
{
  int read_ = analogRead(0);
  Buf[pos_buf] = ((double)read_ - 512.0) * 0.0048828125;
  pos_buf++;
  if (pos_buf == SAMPLES)
    pos_buf = 0;

  if (contador == SAMPLES - 1)
  {
    int pos_buf_aux = pos_buf;
    for (int i = 0; i < SAMPLES; i++)
    {
      BufCalc[i] = Buf[pos_buf_aux];
      pos_buf_aux++;
      if (pos_buf_aux == SAMPLES)
        pos_buf_aux = 0;
    }
    //double F1 = F_EMG.NEMAV();
    double F2 = F_EMG.NMAV();
    //double F3 = F_EMG.NRMS();
    //double F4 = F_EMG.NAAC();
    double F5 = F_EMG.NDASDV();
    double F6 = F_EMG.NMMAV();
    double F7 = F_EMG.NMMAV2();
    //double F8 = F_EMG.NVAR();

    int result = clasificador(F2,F5,F6,F7);
 
    if(result == 1) 
    {
      Serial.println("ABIERTA");
      tipo1();
    }
    else 
    {
      Serial.println("CERRADA");
      tipo2();
    }
  }
  contador++;
  if (contador == SAMPLES)
    contador = 0;
}

int clasificador(double F1, double F2, double F3, double F4)
{
  int num_model = length(Coeffs);
  //Inicialización de las variables para la estrategia Majority voting
  int tipo_A = 0;
  int tipo_B = 0;
  //Bucle en el calcularemos el resultado de la ecuación de coeficientes de los n modelos seleccionados para el Majority voting
  for (int i = 0; i < num_model; i++)
  {
    double aux = F1 * Coeffs[i][0] + F2 * Coeffs[i][1] + F3 * Coeffs[i][2] + F4 * Coeffs[i][3] +
                Coeffs[i][4];
    //Si el resultado es menor de 0 tipo_B++
    if (aux < 0)
      tipo_B++;
    //Sino, tipo_A++
    else
      tipo_A++;
  }
  //Aplicamos Majority voting
  if (tipo_A > tipo_B)
    return 1;
  else
    return 2;
}

void tipo1()
{
  digitalWrite(LED1,HIGH); //Setup LED1 state
  digitalWrite(LED2,LOW); //Setup LED1 state
}

void tipo2()
{
  digitalWrite(LED1,LOW); //Setup LED1 state
  digitalWrite(LED2,HIGH); //Setup LED1 state
}

/****************************************************/
/*  Function name: loop                             */
/*  Parameters                                      */
/*    Input   :  No	                            */
/*    Output  :  No                                 */
/*    Action: Puts MCU into sleep mode.             */
/****************************************************/
void loop() {

  __asm__ __volatile__ ("sleep");

}
