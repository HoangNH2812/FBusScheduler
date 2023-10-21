import 'package:flutter/material.dart';
import 'theme.dart';

class ThemeNotifier extends ChangeNotifier {
  ThemeData _currentTheme = lightTheme;

  ThemeData get currentTheme => _currentTheme;

  void switchTheme() {
    if (_currentTheme == lightTheme) {
      _currentTheme = darkTheme;
    } else {
      _currentTheme = lightTheme;
    }
    notifyListeners();
  }
}
