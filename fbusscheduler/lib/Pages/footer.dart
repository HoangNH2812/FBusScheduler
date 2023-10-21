import 'package:fbusscheduler/Utils/colors.dart';
import 'package:fbusscheduler/Utils/custom_icons_icons.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:fbusscheduler/Pages/home_page.dart';
import 'package:fbusscheduler/Pages/route_page.dart';
import 'package:fbusscheduler/Pages/ticket_page.dart';
import 'package:fbusscheduler/Pages/setting_page.dart';

class Footer extends StatefulWidget {
  const Footer({super.key});

  @override
  State<Footer> createState() => FooterState();
}

class FooterState extends State<Footer> {
  int selectedIndex = 0;
  List<Widget> widgetOption = <Widget>[
    HomePage(),
    RoutePage(),
    TicketPage(),
    SettingPage(),
  ];

  void onItemTap(int index) {
    setState(() {
      selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    bool isDark = Theme.of(context).brightness == Brightness.dark;
    return Scaffold(
        body: Center(
          child: widgetOption.elementAt(selectedIndex),
        ),
        bottomNavigationBar: BottomNavigationBar(
          showUnselectedLabels: true,
          items: <BottomNavigationBarItem>[
            BottomNavigationBarItem(
              activeIcon: const Icon(
                CustomIcons.home,
              ),
              icon: const Icon(
                CustomIcons.home,
              ),
              label: 'Trang chủ',
              backgroundColor: isDark ? Colors.grey : primarycolors,
            ),
            BottomNavigationBarItem(
              activeIcon: const Icon(
                CustomIcons.bus_alt,
              ),
              icon: const Icon(
                CustomIcons.bus_alt,
              ),
              label: 'Tuyến đường',
              backgroundColor: isDark ? Colors.grey : primarycolors,
            ),
            BottomNavigationBarItem(
              activeIcon: const Icon(
                CustomIcons.ticket_alt,
              ),
              icon: const Icon(
                CustomIcons.ticket_alt,
              ),
              label: 'Vé xe',
              backgroundColor: isDark ? Colors.grey : primarycolors,
            ),
            BottomNavigationBarItem(
              activeIcon: const Icon(
                CustomIcons.cog,
                // color: Colors.white,
              ),
              icon: const Icon(
                CustomIcons.cog,
                // color: Colors.black,
              ),
              label: 'Cài đặt',
              backgroundColor: isDark ? Colors.grey : primarycolors,
            ),
          ],
          currentIndex: selectedIndex,
          unselectedItemColor: Colors.black,
          selectedItemColor: Colors.white,
          onTap: onItemTap,
        ));
  }
}
