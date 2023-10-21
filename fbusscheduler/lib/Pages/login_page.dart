import 'package:fbusscheduler/Pages/register_page.dart';
import 'package:get/get.dart';
import 'package:fbusscheduler/Utils/square.dart';
import 'package:fbusscheduler/Utils/colors.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import '../Services/google_auth.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

  @override
  LoginState createState() => LoginState();
}

class LoginState extends State<LoginPage> {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();

  void onLoginClicked() async {
    // showDialog(
    //   context: context,
    //   builder: (context) {
    //     return const Center(
    //       child: CircularProgressIndicator(),
    //     );
    //   },
    // );
    try {
      await FirebaseAuth.instance.signInWithEmailAndPassword(
        email: emailController.text,
        password: passwordController.text,
      );
    } on FirebaseAuthException catch (e) {
      if (e.code == 'INVALID_LOGIN_CREDENTIALS') {
        errorMessage();
      }
    }
  }

  void errorMessage() {
    showDialog(
      context: context,
      builder: (context) {
        return const AlertDialog(
          title: Text('Email hoặc mật khẩu không đúng! Xin hãy nhập lại.'),
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        width: double.infinity,
        decoration: const BoxDecoration(
          color: primarycolors,
        ),
        child: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: <Widget>[
              Container(
                margin: const EdgeInsets.fromLTRB(0, 0, 0, 40),
                padding: const EdgeInsets.fromLTRB(67, 0, 48, 24),
                width: double.infinity,
                decoration: const BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.only(
                    bottomRight: Radius.circular(300),
                    bottomLeft: Radius.circular(300),
                  ),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: <Widget>[
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 33, 0, 20),
                      child: const Text(
                        'Fbus Scheduler',
                        style: TextStyle(fontSize: 35, color: primarycolors),
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(64, 0, 83, 20),
                      padding: const EdgeInsets.fromLTRB(30, 40, 30, 40),
                      width: double.infinity,
                      decoration: const BoxDecoration(
                        image: DecorationImage(
                          image: AssetImage(
                            'assets/fbus-scheduler/images/ellipse-1.png',
                          ),
                        ),
                      ),
                      child: Center(
                        child: Image.asset(
                          'assets/fbus-scheduler/images/vector-4Zw.png',
                          width: 50,
                          height: 45.83,
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              Container(
                margin: const EdgeInsets.fromLTRB(28, 0, 28, 28),
                padding: const EdgeInsets.fromLTRB(10, 25, 10, 20),
                width: double.infinity,
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(30),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: <Widget>[
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 0, 20),
                      child: const Text(
                        'Vui lòng đăng nhập bằng Email FPT',
                        style: TextStyle(fontSize: 20, color: primarycolors),
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 0, 20),
                      width: 322,
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: <Widget>[
                          Container(
                            padding: const EdgeInsets.fromLTRB(10, 0, 10, 8),
                            width: double.infinity,
                            decoration: BoxDecoration(
                              border: Border.all(color: primarycolors),
                              color: const Color(0xffffffff),
                              borderRadius: BorderRadius.circular(15),
                              boxShadow: const [
                                BoxShadow(
                                  color: Color(0x3fff4e00),
                                  offset: Offset(0, 2),
                                  blurRadius: 5,
                                ),
                              ],
                            ),
                            child: TextField(
                              controller: emailController,
                              cursorColor: primarycolors,
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 15),
                              decoration: InputDecoration(
                                enabledBorder: UnderlineInputBorder(
                                  borderSide: BorderSide(color: Colors.grey.shade500),
                                ),
                                focusedBorder: UnderlineInputBorder(
                                  borderSide: BorderSide(color: Colors.grey.shade500),
                                ),
                                labelText: 'Email',
                                labelStyle: TextStyle(
                                  color: Colors.grey.shade500,
                                ),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 0, 22),
                      width: 322,
                      child: Column(
                        //crossAxisAlignment: CrossAxisAlignment.start,
                        children: <Widget>[
                          Container(
                            padding: const EdgeInsets.fromLTRB(10, 0, 10, 8),
                            width: double.infinity,
                            decoration: BoxDecoration(
                              border: Border.all(color: primarycolors),
                              color: const Color(0xffffffff),
                              borderRadius: BorderRadius.circular(15),
                              boxShadow: const [
                                BoxShadow(
                                  color: Color(0x56ff4e00),
                                  offset: Offset(0, 2),
                                  blurRadius: 5,
                                ),
                              ],
                            ),
                            child: TextField(
                              cursorColor: primarycolors,
                              controller: passwordController,
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 15),
                              obscureText: true,
                              decoration: InputDecoration(
                                enabledBorder: UnderlineInputBorder(
                                  borderSide: BorderSide(color: Colors.grey.shade500),
                                ),
                                focusedBorder: UnderlineInputBorder(
                                  borderSide: BorderSide(color: Colors.grey.shade500),
                                ),
                                labelText: 'Password',
                                labelStyle:
                                    TextStyle(color: Colors.grey.shade500),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(15, 0, 30, 0),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: <Widget>[
                          ClipRRect(
                            borderRadius: BorderRadius.circular(15),
                            child: Stack(
                              children: <Widget>[
                                Positioned.fill(
                                  child: Container(
                                    margin:
                                        const EdgeInsets.fromLTRB(0, 5, 0, 5),
                                    decoration: BoxDecoration(
                                      border: Border.all(
                                          color: primarycolors),
                                      borderRadius: BorderRadius.circular(15),
                                      boxShadow: const [
                                        BoxShadow(
                                          color: Color(0x3fff4e00),
                                          offset: Offset(0, 2),
                                          blurRadius: 5,
                                        ),
                                      ],
                                    ),
                                  ),
                                ),
                                TextButton(
                                  style: TextButton.styleFrom(
                                    foregroundColor: Colors.black,
                                    padding: const EdgeInsets.all(16.0),
                                    textStyle: const TextStyle(
                                        fontSize: 12,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  onPressed: onLoginClicked,
                                  child: const Text('Đăng nhập'),
                                ),
                              ],
                            ),
                          ),
                          const Text(
                            "hoặc đăng nhập với",
                            style: TextStyle(
                                fontSize: 12,
                                color: Colors.black,
                                fontWeight: FontWeight.bold),
                          ),
                          Square(
                              onTap: () => GoogleAuth().loginWithGoogle(),
                              imgPath:
                                  'assets/fbus-scheduler/images/Google__G__Logo.png')
                        ],
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 19, 0),
                      child: Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: <Widget>[
                            const SizedBox(height: 30),
                            // TextButton(
                            //   style: TextButton.styleFrom(
                            //     textStyle: const TextStyle(fontSize: 15),
                            //   ),
                            //   onPressed: () {
                            //     Navigator.push(
                            //       context,
                            //       MaterialPageRoute(
                            //           builder: (context) =>
                            //               const RegisterPage()),
                            //     );
                            //   },
                            //   child: const Text("Đăng ký tài khoản",
                            //       style: TextStyle(color: primarycolors)),
                            // ),
                            TextButton(
                              style: TextButton.styleFrom(
                                textStyle: const TextStyle(fontSize: 15),
                              ),
                              onPressed: () {},
                              child: const Text("Quên mật khẩu?",
                                  style: TextStyle(color: primarycolors)),
                            ),
                          ]),
                    )
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
