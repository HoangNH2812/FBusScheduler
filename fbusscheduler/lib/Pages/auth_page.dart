import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'footer.dart';
import 'login_page.dart';

class AuthPage extends StatelessWidget{
  const AuthPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: StreamBuilder<User?>(
        stream: FirebaseAuth.instance.authStateChanges(),
        builder: (context,snapshot)   {
          if(snapshot.hasData){
            return Footer();
          }else{
            return LoginPage();
          }
        },
      ),
    );
  }
  
}