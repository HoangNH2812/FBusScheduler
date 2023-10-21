import 'package:fbusscheduler/Models/routes.dart';
import 'package:flutter/material.dart';
import '../Services/api_services.dart';
import '../Utils/colors.dart';

class RoutePage extends StatefulWidget {
  const RoutePage({super.key});

  @override
  _RoutePage createState() => _RoutePage();
}

class _RoutePage extends State<RoutePage> {
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    bool isDark = Theme.of(context).brightness == Brightness.dark;
    return Scaffold(
      appBar: AppBar(
        title: const Text("Danh sách tuyến đường"),
        centerTitle: true,
      ),
      body: Container(
        width: double.infinity,
        decoration: BoxDecoration(
          color: isDark ? const Color(0x00303030) : Colors.white,
        ),
        child: FutureBuilder<List<Routes>>(
          future: ApiRoutesService().fetchRoutes(),
          builder: (context, snapshot) {
            if ((snapshot.hasError) || (!snapshot.hasData)) {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
            List<Routes>? routesList = snapshot.data;
            return ListView.builder(
                itemCount: routesList!.length,
                itemBuilder: (BuildContext context, int index) {
                  return RoutesItem(
                    routes: routesList[index],
                  );
                });
          },
        ),
      ),
    );
  }
}

class RoutesItem extends StatelessWidget {
  Routes? routes;
  RoutesItem({super.key, this.routes});

  @override
  Widget build(BuildContext context) {
    bool isDark = Theme.of(context).brightness == Brightness.dark;
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Container(
          padding: const EdgeInsets.fromLTRB(35, 20, 36, 15),
          width: double.infinity,
          child: Column(crossAxisAlignment: CrossAxisAlignment.center, children: [
            ClipRRect(
              borderRadius: const BorderRadius.only(
                topLeft: Radius.circular(30),
                topRight: Radius.circular(30),
              ),
              child: Image.asset(
                'assets/fbus-scheduler/images/unsplash-qoxgaf27zbc-cRo.png',
                fit: BoxFit.cover,
              ),
            ),
            Container(
              padding: const EdgeInsets.fromLTRB(18, 10, 13, 15),
              width: double.infinity,
              decoration: BoxDecoration(
                border:
                    Border.all(color: isDark ? Colors.white : primarycolors),
                color: isDark ? Colors.grey.shade600 : primarycolors,
                borderRadius: const BorderRadius.only(
                  bottomRight: Radius.circular(30),
                  bottomLeft: Radius.circular(30),
                ),
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Center(
                    child: Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                      width: double.infinity,
                      child: Text(
                        "Tuyến số ${routes!.routeId}: ${routes!.routeName}",
                        textAlign: TextAlign.center,
                        style: const TextStyle(
                            color: Colors.white,
                            fontSize: 16,
                            fontWeight: FontWeight.bold),
                      ),
                    ),
                  ),
                  Center(
                    child: Container(
                      margin: const EdgeInsets.fromLTRB(0, 0, 0, 0),
                      width: double.infinity,
                      child: Text(
                        "Từ ${routes!.startingLocation} đến ${routes!.destination}",
                        textAlign: TextAlign.center,
                        style: const TextStyle(
                          color: Colors.white,
                          fontSize: 16,
                        ),
                      ),
                    ),
                  ),
                  // Row(
                  //   children: [
                  //     Container(
                  //       margin: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                  //       width: 149,
                  //       height: 32,
                  //       child: Center(
                  //         child: Text(
                  //           "Khoảng cách: ${routes!.distance}",
                  //           style:
                  //           const TextStyle(color: Colors.white, fontSize: 15),
                  //           textAlign: TextAlign.center,
                  //         ),
                  //       ),
                  //     ),
                  //     Container(
                  //       margin: const EdgeInsets.fromLTRB(17, 0, 0, 0),
                  //       width: 117,
                  //       height: 37,
                  //       decoration: BoxDecoration(
                  //         border: Border.all(color: Colors.white),
                  //         color: isDark ? Colors.grey : primarycolors,
                  //         borderRadius: BorderRadius.circular(5),
                  //       ),
                  //       child: Center(
                  //         child: TextButton(
                  //           onPressed: () {},
                  //           child: const Text("Đặt xe ngay",
                  //               style: TextStyle(color: Colors.white)),
                  //         ),
                  //       ),
                  //     ),
                  //   ],
                  // ),
                 Center(
                   child: Container(
                     margin: const EdgeInsets.fromLTRB(0, 10, 0, 15),
                     child: Text(
                       "Khoảng cách: ${routes!.distance}",
                       style:
                       const TextStyle(color: Colors.white, fontSize: 15),
                       textAlign: TextAlign.center,
                     ),
                   ),
                    ),
                  Container(
                    margin: const EdgeInsets.fromLTRB(5, 0, 5, 0),
                    height: 40,
                    decoration: BoxDecoration(
                      border: Border.all(color: Colors.white),
                      color: isDark ? Colors.grey : primarycolors,
                      borderRadius: BorderRadius.circular(5),
                    ),
                    child: Center(
                      child: TextButton(
                        onPressed: () {},
                        child: const Text("Đặt vé ngay",
                            style: TextStyle(color: Colors.white,fontSize: 18)),
                      ),
                    ),
                  ),

                ],
              ),
            ),
          ]),
        ),
      ],
    );
  }
}
