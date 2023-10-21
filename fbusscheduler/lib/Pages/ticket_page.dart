import 'package:fbusscheduler/Models/tickets.dart';
import 'package:fbusscheduler/Utils/colors.dart';
import 'package:flutter/material.dart';
import '../Services/api_services.dart';

class TicketPage extends StatefulWidget {
  const TicketPage({super.key});

  @override
  _TicketPage createState() => _TicketPage();
}

class _TicketPage extends State<TicketPage> {
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    bool isDark = Theme.of(context).brightness == Brightness.dark;
    return Scaffold(
      appBar: AppBar(
        title: const Text("Danh sách vé"),
        centerTitle: true,
      ),
      body: Container(
        width: double.infinity,
        decoration: BoxDecoration(
          color: isDark ? const Color(0x00303030) : Colors.white,
        ),
        child: FutureBuilder<List<Ticket>>(
          future: ApiTicketService().fetchTicket(),
          builder: (context, snapshot) {
            if ((snapshot.hasError) || (!snapshot.hasData)) {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
            List<Ticket>? ticketList = snapshot.data;
            return ListView.builder(
                itemCount: ticketList!.length,
                itemBuilder: (BuildContext context, int index) {
                  return TicketItem(
                    ticket: ticketList[index],
                  );
                });
          },
        ),
      ),
    );
  }
}

class TicketItem extends StatelessWidget {
  Ticket? ticket;
  TicketItem({super.key, this.ticket});
  @override
  Widget build(BuildContext context) {
    bool isDark = Theme.of(context).brightness == Brightness.dark;
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: <Widget>[
        Container(
          padding: const EdgeInsets.fromLTRB(35, 20, 36, 15),
          width: double.infinity,
          child: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: <Widget>[
                ClipRRect(
                  borderRadius: const BorderRadius.only(
                    topLeft: Radius.circular(30),
                    topRight: Radius.circular(30),
                  ),
                  child: Image.asset(
                    'assets/fbus-scheduler/images/unsplash-qoxgaf27zbc.png',
                    fit: BoxFit.cover,
                  ),
                ),
                Container(
                  padding: const EdgeInsets.fromLTRB(10, 10, 10, 15),
                  width: double.infinity,
                  decoration: BoxDecoration(
                    border: Border.all(
                        color: isDark ? Colors.white : primarycolors),
                    color: isDark ? Colors.grey.shade600 : primarycolors,
                    borderRadius: const BorderRadius.only(
                      bottomRight: Radius.circular(30),
                      bottomLeft: Radius.circular(30),
                    ),
                  ),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: <Widget>[
                      Center(
                        child: Container(
                          margin: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                          width: double.infinity,
                          child: const Text(
                            "Vinhomes Grand Park - Campus khu CNC",
                            textAlign: TextAlign.center,
                            style: TextStyle(
                                color: Colors.white,
                                fontSize: 16,
                                fontWeight: FontWeight.bold),
                          ),
                        ),
                      ),
                      Center(
                        child: Container(
                          margin: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                          width: double.infinity,
                          child: Text(
                            "Khởi hành lúc: ${ticket!.departurTime}",
                            textAlign: TextAlign.center,
                            style: const TextStyle(
                              color: Colors.white,
                            ),
                          ),
                        ),
                      ),
                      Center(
                        child: Container(
                          margin: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                          width: double.infinity,
                          child: Text(
                            "Kết thúc lúc: ${ticket!.arrivalTime}",
                            textAlign: TextAlign.center,
                            style: const TextStyle(
                              color: Colors.white,
                            ),
                          ),
                        ),
                      ),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: <Widget>[
                          Container(
                            margin: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                            width: 149,
                            height: 32,
                            child: Center(
                              child: Text(
                                ticket!.customerName.toString(),
                                style: const TextStyle(
                                    color: Colors.white,
                                    fontSize: 16,
                                    fontWeight: FontWeight.bold),
                              ),
                            ),
                          ),
                          Container(
                            margin: const EdgeInsets.fromLTRB(0, 0, 0, 10),
                            width: 149,
                            height: 32,
                            child: Center(
                              child: Text(
                                "Mã vé: #${ticket!.ticketId}",
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 15),
                              ),
                            ),
                          ),
                        ],
                      ),
                      // Row(
                      //   mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      //   children: <Widget>[
                          Container(
                           margin: const EdgeInsets.fromLTRB(10, 0, 10, 0),
                            height: 40,
                            decoration: BoxDecoration(
                              border: Border.all(color: Colors.white),
                              color: isDark ? Colors.grey : primarycolors,
                              borderRadius: BorderRadius.circular(5),
                            ),
                            child: Center(
                              child: TextButton(
                                onPressed: () {},
                                child: const Text("Xem chi tiết",
                                    style: TextStyle(color: Colors.white,fontSize: 18)),
                              ),
                            ),
                          ),
                        //],
                      //)
                    ],
                  ),
                ),
              ]),
        ),
      ],
    );
  }
}
