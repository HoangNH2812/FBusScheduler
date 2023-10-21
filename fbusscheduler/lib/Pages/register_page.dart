import 'package:fbusscheduler/Pages/login_page.dart';
import 'package:fbusscheduler/Utils/colors.dart';
import 'package:flutter/material.dart';

class RegisterPage extends StatefulWidget {
  const RegisterPage({super.key});

  @override
  RegisterState createState() => RegisterState();
}

class RegisterState extends State<RegisterPage> {
  final TextEditingController emailController = TextEditingController();
  final TextEditingController passwordController = TextEditingController();
  final TextEditingController confirmPasswordController =
      TextEditingController();

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
                margin: const EdgeInsets.fromLTRB(0, 0, 0, 30),
                padding: const EdgeInsets.fromLTRB(67, 50, 48, 24),
                width: double.infinity,
                decoration: const BoxDecoration(
                  color: Color(0xffffffff),
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
                        style: TextStyle(fontSize: 30, color: primarycolors),
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(64, 0, 83, 0),
                      padding: const EdgeInsets.fromLTRB(30, 30, 30, 30),
                      width: double.infinity,
                      decoration: const BoxDecoration(
                        image: DecorationImage(
                          image: AssetImage(
                            'assets/fbus-scheduler/images/ellipse-1.png',
                          ),
                        ),
                      ),
                      child: Center(
                        child: SizedBox(
                          width: 50,
                          height: 45.83,
                          child: Image.asset(
                            'assets/fbus-scheduler/images/vector-4Zw.png',
                            width: 50,
                            height: 45.83,
                          ),
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
                  color: const Color(0xffffffff),
                  borderRadius: BorderRadius.circular(30),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: <Widget>[
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 0, 20),
                      child: const Text(
                        'Vui lòng đăng ký bằng Email FPT',
                        style: TextStyle(fontSize: 15, color: primarycolors),
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
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 15),
                              decoration: const InputDecoration(
                                  labelText: 'Email',
                                  labelStyle:
                                      TextStyle(color: Color(0xff888888))),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 0, 22),
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
                                  color: Color(0x56ff4e00),
                                  offset: Offset(0, 2),
                                  blurRadius: 5,
                                ),
                              ],
                            ),
                            child: TextField(
                              controller: passwordController,
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 15),
                              obscureText: true,
                              decoration: const InputDecoration(
                                labelText: 'Password',
                                labelStyle: TextStyle(color: Color(0xff888888)),
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
                                  color: Color(0x56ff4e00),
                                  offset: Offset(0, 2),
                                  blurRadius: 5,
                                ),
                              ],
                            ),
                            child: TextField(
                              controller: passwordController,
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 15),
                              obscureText: true,
                              decoration: const InputDecoration(
                                labelText: 'Confirm Password',
                                labelStyle: TextStyle(color: Color(0xff888888)),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 10, 0),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.end,
                        children: <Widget>[
                          ClipRRect(
                            borderRadius: BorderRadius.circular(15),
                            child: Stack(
                              children: <Widget>[
                                Positioned.fill(
                                  child: Container(
                                    decoration: BoxDecoration(
                                      border: Border.all(
                                          color: const Color(0xffff5b00)),
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
                                        fontSize: 15,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  onPressed: onRegisterClicked,
                                  child: const Text('Đăng ký'),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                    ),
                    Container(
                      child: Row(
                          mainAxisAlignment: MainAxisAlignment.end,
                          children: <Widget>[
                            const SizedBox(height: 30),
                            TextButton(
                              style: TextButton.styleFrom(
                                textStyle: const TextStyle(fontSize: 15),
                              ),
                              onPressed: () {
                                Navigator.push(
                                  context,
                                  MaterialPageRoute(
                                      builder: (context) => const LoginPage()),
                                );
                              },
                              child: const Text(
                                  "Đã có tài khoản? Hãy đăng nhập",
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

  void onRegisterClicked() {}
}
