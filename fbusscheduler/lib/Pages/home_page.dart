import 'package:fbusscheduler/Models/customers.dart';
import 'package:flutter/material.dart';
import '../Services/api_services.dart';

class HomePage extends StatefulWidget {
  @override
  _HomePage createState() => _HomePage();
}

class _HomePage extends State<HomePage> {
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return Scaffold(
      appBar: AppBar(
        title: Text("Danh sách người dùng"),
        centerTitle: true,
      ),
      body: Container(
        padding: EdgeInsets.only(left: 10),
        height: MediaQuery.of(context).size.height,
        width: MediaQuery.of(context).size.height,
        child: FutureBuilder<List<Customer>>(
          future: ApiCustomerService().fetchCustomer(),
          builder: (context, snapshot) {
            if ((snapshot.hasError) || (!snapshot.hasData))
              return Container(
                child: Center(
                  child: CircularProgressIndicator(),
                ),
              );
            List<Customer>? customerList = snapshot.data;
            return ListView.builder(
                itemCount: customerList!.length,
                itemBuilder: (BuildContext context, int index) {
                  return CustomerItem(
                    customer: customerList[index],
                  );
                });
          },
        ),
      ),
    );
  }
}

class CustomerItem extends StatelessWidget {
  Customer? customer;
  CustomerItem({this.customer});
  @override
  Widget build(BuildContext context) {
    // TODO: implement build
    return Container(
      margin: EdgeInsets.only(top: 20.0),
      child: Column(
        children: <Widget>[
          Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: <Widget>[
              Container(
                margin: EdgeInsets.only(top: 10.0),
                child: Text(
                  customer!.customerId.toString(),
                  style: TextStyle(
                    fontSize: 15.0,
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.only(top: 10.0),
                child: Text(
                  customer!.customerName.toString(),
                  style: TextStyle(
                    fontSize: 15.0,
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.only(top: 10.0),
                child: Text(
                  customer!.age.toString(),
                  style: TextStyle(
                    fontSize: 15.0,
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.only(top: 10.0),
                child: Text(
                  customer!.email.toString(),
                  style: TextStyle(
                    fontSize: 15.0,
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.only(top: 10.0),
                child: Text(
                  customer!.status.toString(),
                  style: TextStyle(
                    fontSize: 15.0,
                  ),
                ),
              ),
            ],
          )
        ],
      ),
    );
  }
}
