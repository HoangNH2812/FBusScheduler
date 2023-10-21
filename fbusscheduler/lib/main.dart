import 'package:fbusscheduler/Pages/footer.dart';
import 'package:fbusscheduler/Pages/auth_page.dart';
import 'package:fbusscheduler/Pages/login_page.dart';
import 'package:fbusscheduler/Services/push_notification.dart';
import 'package:fbusscheduler/Utils/theme.dart';
import 'package:fbusscheduler/Utils/theme_notifier.dart';
import 'package:flutter/material.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:provider/provider.dart';
import 'Utils/colors.dart';
import 'Services/firebase_options.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp(
    options: DefaultFirebaseOptions.currentPlatform,
  );
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  MyApp({super.key});
  @override
  Widget build(BuildContext context) {
    // return MaterialApp(
    //     title: 'FBus Scheduler',
    //     debugShowCheckedModeBanner: false,
    //     theme: ThemeData(
    //       primarySwatch: primarycolors,
    //     ),
    //     // themeMode: _themeManager.themeMode,
    //     home: Footer()
    //     //home: AuthPage()
    //     );
    return ChangeNotifierProvider(
      create: (_) => ThemeNotifier(),
      child: Consumer<ThemeNotifier>(
        builder: (context, ThemeNotifier notifier, child) {
          return MaterialApp(
            theme: notifier.currentTheme,
            home: AuthPage(),
          );
        },
      ),
    );
  }
}
