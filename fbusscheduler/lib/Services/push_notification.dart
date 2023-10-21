import 'package:firebase_core/firebase_core.dart';
import 'package:firebase_messaging/firebase_messaging.dart';

class PushNotification {
  final pushMessage = FirebaseMessaging.instance;
  Future<void> initNotification() async {
    await Firebase.initializeApp();
    await FirebaseMessaging.instance.getInitialMessage();
    // await _pushMessage.requestPermission();
    // final FCMtoken = await _pushMessage.getToken();
    // print('Token: $FCMtoken');
  }
}
