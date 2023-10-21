import 'package:fbusscheduler/Utils/colors.dart';
import 'package:fbusscheduler/Utils/theme_notifier.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class SettingPage extends StatefulWidget {
  const SettingPage({super.key});

  //final controller = Get.put(GoogleAuth());
  @override
  _SettingPage createState() => _SettingPage();
}
void logout() {
  FirebaseAuth.instance.signOut();
}
class _SettingPage extends State<SettingPage> {
  GestureDetector buildTextOption(BuildContext context, String title) {
    return GestureDetector(
      onTap: () {
        showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(
                title: Text(title),
                content: const Column(
                  mainAxisSize: MainAxisSize.min,
                  children: [Text("text 1"), Text("text 2")],
                ),
                actions: [
                  TextButton(
                      onPressed: () {
                        Navigator.of(context).pop();
                      },
                      child: const Text('Close'))
                ],
              );
            });
      },
      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 14, horizontal: 10),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text(
              title,
              style: const TextStyle(fontSize: 15, color: Colors.black),
            ),
            Image.asset(
              'assets/fbus-scheduler/images/group-14.png',
              width: 24,
              height: 24,
            ),
          ],
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    bool isDark = Theme.of(context).brightness == Brightness.dark;
    return Scaffold(
      body: Container(
        width: double.infinity,
        decoration: BoxDecoration(
          color: isDark ? const Color(0x00303030) : Colors.white60,
        ),
        child: SingleChildScrollView(
          child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: <Widget>[
                Container(
                  margin: const EdgeInsets.fromLTRB(0, 0, 0, 0),
                  width: double.infinity,
                  height: 800,
                  child: Stack(children: <Widget>[
                    Positioned(
                      left: 10,
                      child: Align(
                        child: SizedBox(
                          width: 390,
                          height: 200,
                          child: Container(
                              decoration: BoxDecoration(
                                color: isDark ? Colors.grey : primarycolors,
                                borderRadius: const BorderRadius.only(
                                  bottomRight: Radius.circular(30),
                                  bottomLeft: Radius.circular(30),
                                ),
                              ),
                              child: Column(
                                mainAxisAlignment: MainAxisAlignment.start,
                                crossAxisAlignment: CrossAxisAlignment.center,
                                children: [
                                  Container(
                                    margin:
                                        const EdgeInsets.fromLTRB(0, 40, 0, 30),
                                    child: const Text(
                                      'Your profile',
                                      style: TextStyle(
                                          color: Colors.white, fontSize: 30),
                                    ),
                                  ),
                                ],
                              )),
                        ),
                      ),
                    ),
                    Positioned(
                      left: 25,
                      top: 100,
                      child: Align(
                        child: SizedBox(
                          width: 359,
                          height: 650,
                          child: Container(
                            decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(16),
                              color:
                                  isDark ? Colors.grey.shade400 : Colors.white,
                              boxShadow: const [
                                BoxShadow(
                                  color: Color(0x264b4b4b),
                                  offset: Offset(0, 2),
                                  blurRadius: 8,
                                ),
                              ],
                            ),
                          ),
                        ),
                      ),
                    ),
                    Positioned(
                      left: 40,
                      top: 140,
                      child: SizedBox(
                        width: 283,
                        height: 65,
                        child: Row(
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: [
                            // Container(
                            //   margin: const EdgeInsets.fromLTRB(0, 0, 19.61, 0),
                            //   width: 59.39,
                            //   height: 65,
                            //   child: CircleAvatar(
                            //     backgroundImage: Image.network('').image,
                            //     // assets/fbus-scheduler/images/avatar.png
                            //     // width: 59.39,
                            //     // height: 65,
                            //   ),
                            // ),
                            Expanded(
                                  child: Text("Xin chào: ",
                                      overflow: TextOverflow.ellipsis,
                                      style: TextStyle(color: isDark?Colors.black:Colors.black,fontSize: 20)),
                              ),
                          ],
                        ),
                      ),
                    ),
                    Positioned(
                      left: 35,
                      top: 230,
                      child: SizedBox(
                        width: 329,
                        height: 270,
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Container(
                              margin: const EdgeInsets.fromLTRB(0, 0, 0, 8),
                              child: Text(
                                'Account Settings',
                                style: (TextStyle(
                                  color: isDark
                                      ? Colors.grey.shade50
                                      : Colors.grey,
                                  fontSize: 15,
                                )),
                              ),
                            ),
                            buildTextOption(context, 'Edit profile'),
                            buildTextOption(context, 'Change password'),
                            Padding(
                              padding: const EdgeInsets.symmetric(
                                  vertical: 5, horizontal: 10),
                              child: Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: [
                                  const Text(
                                    "Push notifications",
                                    style: TextStyle(
                                      fontSize: 15,
                                      color: Colors.black,
                                    ),
                                  ),
                                  Transform.scale(
                                    scaleX: 1,
                                    scaleY: 1,
                                    child: CupertinoSwitch(
                                      activeColor: isDark
                                          ? Colors.grey.shade800
                                          : primarycolors,
                                      trackColor: Colors.grey,
                                      value: true,
                                      onChanged: (bool newValue) {},
                                    ),
                                  )
                                ],
                              ),
                            ),
                            Padding(
                              padding: const EdgeInsets.symmetric(
                                  vertical: 5, horizontal: 10),
                              child: Row(
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                children: [
                                  const Text(
                                    "Dark mode",
                                    style: TextStyle(
                                      fontSize: 15,
                                      color: Colors.black,
                                    ),
                                  ),
                                  Transform.scale(
                                    scaleX: 1,
                                    scaleY: 1,
                                    child: CupertinoSwitch(
                                      activeColor: isDark
                                          ? Colors.grey.shade800
                                          : primarycolors,
                                      trackColor: Colors.grey,
                                      value: Provider.of<ThemeNotifier>(context)
                                              .currentTheme
                                              .brightness ==
                                          Brightness.dark,
                                      onChanged: (bool newValue) {
                                        Provider.of<ThemeNotifier>(context,
                                                listen: false)
                                            .switchTheme();
                                      },
                                    ),
                                  )
                                ],
                              ),
                            ),
                            const Divider(
                              height: 10,
                              thickness: 1.5,
                            ),
                          ],
                        ),
                      ),
                    ),
                    Positioned(
                      left: 35,
                      top: 500,
                      child: SizedBox(
                        width: 329,
                        height: 250,
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Container(
                              margin: const EdgeInsets.fromLTRB(0, 0, 0, 8),
                              child: Text(
                                'More',
                                style: TextStyle(
                                  fontSize: 15,
                                  color: isDark
                                      ? Colors.grey.shade50
                                      : Colors.grey,
                                ),
                              ),
                            ),
                            buildTextOption(context, 'About us'),
                            buildTextOption(context, 'Privacy policy'),
                            buildTextOption(context, 'Term and conditions'),
                            Container(
                              margin: const EdgeInsets.fromLTRB(15, 10, 15, 0),
                              height: 40,
                              decoration: BoxDecoration(
                                border: Border.all(color: isDark?Colors.white:Colors.black),
                                color: isDark ? Colors.grey : Colors.white,
                                borderRadius: BorderRadius.circular(5),
                              ),
                              child: Center(
                                child: TextButton(
                                  onPressed: logout,
                                  child: Text("Đăng xuất",
                                      style: TextStyle(color: isDark?Colors.white:Colors.black54,fontSize: 18)),
                                ),
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                  ]),
                ),
              ]),
        ),
      ),
    );
  }
}
