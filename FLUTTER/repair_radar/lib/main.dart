import 'dart:async';

import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ReparApp',
      theme: ThemeData(
        primarySwatch: Colors.yellow,
        visualDensity: VisualDensity.adaptivePlatformDensity,
        appBarTheme: AppBarTheme(
          iconTheme: IconThemeData(color: Colors.white), // Icono del menú hamburguesa en color blanco
        ),
      ),
      home: LoginPage(),
    );
  }
}

class LoginPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Iniciar Sesión', style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.black, // Fondo negro para la barra de navegación
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            DrawerHeader(
              child: Text('Menú', style: TextStyle(color: Colors.black)), // Texto negro para el encabezado del menú
              decoration: BoxDecoration(
                color: Colors.yellow[200], // Fondo amarillo claro para el encabezado del menú
              ),
            ),
            ListTile(
              title: Text('Inicio', style: TextStyle(color: Colors.black)), // Texto negro para los elementos del menú
              onTap: () {
                Navigator.pop(context); // Cerrar el Drawer
                Navigator.push(context, MaterialPageRoute(builder: (context) => HomeScreen()));
              },
            ),
            ListTile(
              title: Text('Registrarse', style: TextStyle(color: Colors.black)), // Texto negro para los elementos del menú
              onTap: () {
                Navigator.pop(context); // Cerrar el Drawer
                Navigator.push(context, MaterialPageRoute(builder: (context) => RegisterPage()));
              },
            ),
          ],
        ),
      ),
      body: Container(
        decoration: BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
            colors: [Colors.yellow[200]!, Colors.yellow[400]!], // Gradiente de amarillo claro a amarillo medio
          ),
        ),
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Image.asset(
                'assets/logo.png', // Ruta de la imagen del logo
                width: 150, // Ancho del logo
              ),
              SizedBox(height: 30),
              ElevatedButton(
                onPressed: () {
                  // Lógica para iniciar sesión con correo electrónico
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Iniciar Sesión con Correo Electrónico', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  // Lógica para iniciar sesión con número de teléfono
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Iniciar Sesión con Número de Teléfono', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  // Lógica para iniciar sesión con cuenta de Google
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Iniciar Sesión con Google', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  // Lógica para iniciar sesión con Facebook
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Iniciar Sesión con Facebook', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
              SizedBox(height: 20),
              TextButton(
                onPressed: () {
                  Navigator.push(context, MaterialPageRoute(builder: (context) => RegisterPage()));
                },
                child: Text('Crear una cuenta', style: TextStyle(color: Colors.black)), // Texto negro para el botón
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class RegisterPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Registro', style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.black, // Fondo negro para la barra de navegación
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            DrawerHeader(
              child: Text('Menú', style: TextStyle(color: Colors.black)), // Texto negro para el encabezado del menú
              decoration: BoxDecoration(
                color: Colors.yellow[200], // Fondo amarillo claro para el encabezado del menú
              ),
            ),
            ListTile(
              title: Text('Inicio', style: TextStyle(color: Colors.black)), // Texto negro para los elementos del menú
              onTap: () {
                Navigator.pop(context); // Cerrar el Drawer
                Navigator.push(context, MaterialPageRoute(builder: (context) => HomeScreen()));
              },
            ),
            ListTile(
              title: Text('Iniciar Sesión', style: TextStyle(color: Colors.black)), // Texto negro para los elementos del menú
              onTap: () {
                Navigator.pop(context); // Cerrar el Drawer
                Navigator.push(context, MaterialPageRoute(builder: (context) => LoginPage()));
              },
            ),
          ],
        ),
      ),
      body: Container(
        decoration: BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
            colors: [Colors.yellow[200]!, Colors.yellow[400]!], // Gradiente de amarillo claro a amarillo medio
          ),
        ),
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Text('Seleccione una opción para registrarse:', style: TextStyle(color: Colors.black)), // Texto negro para la pregunta
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: () {
                  // Lógica para registrarse con correo electrónico
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Registrarse con Correo Electrónico', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  // Lógica para registrarse con número de teléfono
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Registrarse con Número de Teléfono', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  // Lógica para registrarse con cuenta de Google
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Registrarse con Google', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
              SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  // Lógica para registrarse con Facebook
                },
                style: ButtonStyle(
                  backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                ),
                child: Text('Registrarse con Facebook', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class HomeScreen extends StatefulWidget {
  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  Completer<GoogleMapController> _controller = Completer();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('ReparApp', style: TextStyle(color: Colors.white)),
        backgroundColor: Colors.black, // Fondo negro para la barra de navegación
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            DrawerHeader(
              child: Text('Menú', style: TextStyle(color: Colors.black)), // Texto negro para el encabezado del menú
              decoration: BoxDecoration(
                color: Colors.yellow[200], // Fondo amarillo claro para el encabezado del menú
              ),
            ),
            ListTile(
              title: Text('Registrarse', style: TextStyle(color: Colors.black)), // Texto negro para los elementos del menú
              onTap: () {
                Navigator.pop(context); // Cerrar el Drawer
                Navigator.push(context, MaterialPageRoute(builder: (context) => RegisterPage()));
              },
            ),
            ListTile(
              title: Text('Iniciar Sesión', style: TextStyle(color: Colors.black)), // Texto negro para los elementos del menú
              onTap: () {
                Navigator.pop(context); // Cerrar el Drawer
                Navigator.push(context, MaterialPageRoute(builder: (context) => LoginPage()));
              },
            ),
          ],
        ),
      ),
      body: Column(
        children: [
          Expanded(
            child: Container(
              // Aquí irá el mapa
              child: GoogleMap(
                mapType: MapType.normal,
                initialCameraPosition: CameraPosition(
                  target: LatLng(0, 0), // Latitud y longitud inicial
                  zoom: 15.0, // Zoom inicial
                ),
                markers: Set<Marker>.from([
                  Marker(
                    markerId: MarkerId('reparador1'),
                    position: LatLng(0, 0), // Latitud y longitud del reparador
                    infoWindow: InfoWindow(title: 'Reparador 1'),
                  ),
                  // Puedes agregar más marcadores para más reparadores si es necesario
                ]),
                onMapCreated: (GoogleMapController controller) {
                  _controller.complete(controller);
                },
              ),
            ),
          ),
          SizedBox(height: 20),
          Padding(
            padding: EdgeInsets.all(20),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                Text('Complete el formulario para encontrar un reparador', style: TextStyle(color: Colors.black)), // Texto negro para la pregunta
                SizedBox(height: 10),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Categoría del daño'),
                ),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Tipo de daño'),
                ),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Ciudad del daño'),
                ),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Dirección del daño'),
                ),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Descripción del daño (opcional)'),
                ),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Adjuntar evidencia (foto)'),
                ),
                TextFormField(
                  decoration: InputDecoration(labelText: 'Ofrecer tarifa'),
                ),
                SizedBox(height: 20),
                ElevatedButton(
                  onPressed: () {
                    // Lógica para encontrar reparador
                  },
                  style: ButtonStyle(
                    backgroundColor: MaterialStateProperty.all<Color>(Colors.red), // Fondo rojo para el botón
                  ),
                  child: Text('Encontrar Reparador', style: TextStyle(color: Colors.white)), // Texto blanco para el botón
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
