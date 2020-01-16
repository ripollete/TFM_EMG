/**********************************************************/
/* ADC para :                                             */
/*    Board: SHIELD-EKG/EMG + ARDUINO UNO                 */
/*  Diseñado:  Javier Ripoll Esteve                       */
/**********************************************************/
/**********************************************************/

#include <compat/deprecated.h>
#include <FlexiTimer2.h>
//http://www.arduino.cc/playground/Main/FlexiTimer2

// All definitions
#define NUMCHANNELS 1
#define HEADERLEN 2
#define PACKETLEN (NUMCHANNELS * 2 + HEADERLEN)
#define SAMPFREQ 1024                    // ADC sampling rate 1024
#define TIMER2VAL (1024/(SAMPFREQ))       // Set 1024Hz sampling frequency                    
#define CAL_SIG 9

#define LED8 8
#define LED9 9
#define LED10 10
#define LED11 11
#define LED12 12
#define LED13 13
#define tiempoMuestra 5 //segundos
#define numRep 5



// Global constants and variables

volatile unsigned char TXBuf[PACKETLEN];  //The transmission packet
volatile unsigned char TXIndex;           //Next byte to write in the transmission packet.
volatile unsigned char counter = 0;	  //Additional divider used to generate CAL_SIG
volatile unsigned int ADC_Value = 0;	  //ADC current value
volatile unsigned int num = SAMPFREQ;
volatile uint32_t i = 0;
volatile uint32_t numMuestras =3;
volatile uint32_t numMuestrasTotalRegistro;
volatile uint32_t tiempoRegistro;
uint8_t segundos;
uint32_t total;
volatile bool transmitir_a_serial;
volatile unsigned int repactual = 0;
volatile unsigned int muestraactual = -1;


const int  buttonPin = 2;    // the pin that the pushbutton is attached to
int buttonState = 1;
int flag=0;
int lastButtonState = 1;     // previous state of the button


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

//Write packet header and footer
 TXBuf[0] = 0xa5;    //Sync 0
 TXBuf[1] = 0x5a;    //Sync 1
 TXBuf[2] = 0x02;    //CH1 High Byte
 TXBuf[3] = 0x00;    //CH1 Low Byte
 
 noInterrupts();  // Disable all interrupts before initialization


  pinMode(LED8, OUTPUT);  //Setup LED1 direction
  pinMode(LED9, OUTPUT);  //Setup LED1 direction
  pinMode(LED10, OUTPUT);  //Setup LED1 directioN
  pinMode(LED11, OUTPUT);  //Setup LED1 direction
  pinMode(LED12, OUTPUT);  //Setup LED1 direction
  pinMode(LED13, OUTPUT);  //Setup LED1 direction
  digitalWrite(LED8,HIGH); //Setup LED1 state
  digitalWrite(LED9,HIGH); //Setup LED1 state
  digitalWrite(LED10,HIGH); //Setup LED1 state
  digitalWrite(LED11,HIGH); //Setup LED1 state
  digitalWrite(LED12,HIGH); //Setup LED1 state
  digitalWrite(LED13,HIGH); //Setup LED1 state

 // Timer2
 // Timer2 is used to setup the analag channels sampling frequency and packet update.
 // Whenever interrupt occures, the current read packet is sent to the PC
 // In addition the CAL_SIG is generated as well, so Timer1 is not required in this case!
 FlexiTimer2::set(TIMER2VAL, Timer2_Overflow_ISR);

 
 // Serial Port
 Serial.begin(57600);
 
 interrupts();  // Enable all interrupts after initialization has been completed
}



void reinicioLEDS()
{
    digitalWrite(LED8,HIGH);
    digitalWrite(LED9,HIGH);
    digitalWrite(LED10,HIGH);
    digitalWrite(LED11,HIGH);
    digitalWrite(LED12,HIGH);
    digitalWrite(LED13,HIGH);
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
  if(i%(SAMPFREQ) == 0)
  {
    
    if(segundos%tiempoMuestra == 0)
    {
      digitalWrite(LED8,HIGH);
      digitalWrite(LED9,LOW);
      digitalWrite(LED10,LOW);
      digitalWrite(LED11,LOW);
      digitalWrite(LED12,LOW);
    }

    else if(segundos%tiempoMuestra == 1)
    {
      digitalWrite(LED8,HIGH);
      digitalWrite(LED9,HIGH);
      digitalWrite(LED10,LOW);
      digitalWrite(LED11,LOW);
      digitalWrite(LED12,LOW);
    }

    else if(segundos%tiempoMuestra == 2)
    {
      digitalWrite(LED8,HIGH);
      digitalWrite(LED9,HIGH);
      digitalWrite(LED10,HIGH);
      digitalWrite(LED11,LOW);
      digitalWrite(LED12,LOW);
    }

    else if(segundos%tiempoMuestra == 3)
    {
      digitalWrite(LED8,HIGH);
      digitalWrite(LED9,HIGH);
      digitalWrite(LED10,HIGH);
      digitalWrite(LED11,HIGH);
      digitalWrite(LED12,LOW);
    }

    else if(segundos%tiempoMuestra == 4)
    {
      digitalWrite(LED8,HIGH);
      digitalWrite(LED9,HIGH);
      digitalWrite(LED10,HIGH);
      digitalWrite(LED11,HIGH);
      digitalWrite(LED12,HIGH);
    }
    segundos++;

  }
  
  if(i<total)
  {
    ADC_Value = analogRead(0);
    TXBuf[(HEADERLEN)] = ((unsigned char)((ADC_Value & 0xFF00) >> 8));  // Write High Byte
    TXBuf[(HEADERLEN + 1)] = ((unsigned char)(ADC_Value & 0x00FF)); // Write Low Byte

    for(TXIndex=0;TXIndex<(2 * NUMCHANNELS + HEADERLEN);TXIndex++)
      Serial.write(TXBuf[TXIndex]);
    i++;
  }
  else
  {
    TXBuf[(HEADERLEN)] = ((unsigned char)((0xFFFF) >> 8));  // Write High Byte
    TXBuf[(HEADERLEN + 1)] = ((unsigned char)(0xFFFF)); // Write Low Byte

    for(TXIndex=0;TXIndex<(2 * NUMCHANNELS + HEADERLEN);TXIndex++)
      Serial.write(TXBuf[TXIndex]);
    FlexiTimer2::stop();
    reinicioLEDS();
    
  }
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

  if(Serial.available() > 0 ){
    char Dato = Serial.read();
    if(Dato == 'A' || Dato == 'B' || Dato == 'P')
    {
      i = 0;
      switch(Dato)
      {
        case 'A':
          //Serial.println("Configurar A");
          numMuestras = 2;
          break;
        case 'B':
          //Serial.println("Configurar B");
          numMuestras = 3;
          break;
        case 'P':
          //Serial.println("Configurar P");
          numMuestras = 0;
          break;
      }

      numMuestrasTotalRegistro =  2 + (numMuestras * numRep);
      tiempoRegistro = numMuestrasTotalRegistro * (uint32_t) tiempoMuestra;
      total = (uint32_t)SAMPFREQ * tiempoRegistro ;//* (uint32_t)2;
      i = 0;
      segundos = 0;

      digitalWrite(LED13,LOW); //Setup LED1 state
      FlexiTimer2::start();
    }
  }
}
