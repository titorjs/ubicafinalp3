// Basic demo for accelerometer readings from Adafruit MPU6050
#include <SoftwareSerial.h>
#include <Adafruit_MPU6050.h>
#include <Adafruit_Sensor.h>
#include <Wire.h>
#include <DHT.h>
#include <DHT_U.h>
#define DHTPIN 11
#define DHTTYPE DHT22

DHT_Unified dht(DHTPIN, DHTTYPE);

Adafruit_MPU6050 mpu;

SoftwareSerial mySerial(12, 13);

void setup(void) {
  Serial.begin(9600);
  mySerial.begin(9600);
  
  // Try to initialize!
  mpu.begin();
  mpu.setAccelerometerRange(MPU6050_RANGE_16_G);
  mpu.setGyroRange(MPU6050_RANGE_1000_DEG);
  mpu.setFilterBandwidth(MPU6050_BAND_5_HZ);
  dht.begin();
}

void loop() {

  /* Get new sensor events with the readings */
  sensors_event_t a, g, temp, dhtet, dhteh;
  mpu.getEvent(&a, &g, &temp);
  dht.temperature().getEvent(&dhtet);
  dht.humidity().getEvent(&dhteh);

  //Formato de envío: gx:gy:gz:dhtt:dhth
  mySerial.print(g.gyro.x - 0.09);
  mySerial.print(":");
  mySerial.print(g.gyro.y + 0.02);
  mySerial.print(":");
  mySerial.print(g.gyro.z + 0.08);
  mySerial.print(":");
  mySerial.print(dhtet.temperature);
  mySerial.print(":");
  mySerial.println(dhteh.relative_humidity);

  delay(5000);
}