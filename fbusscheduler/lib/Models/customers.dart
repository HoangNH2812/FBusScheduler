
class Customer {
  int? customerId;
  String? customerName;
  int? age;
  String? email;
  bool? status;
  List<dynamic>? tickets;

  Customer({this.customerId, this.customerName, this.age, this.email, this.status, this.tickets});

  Customer.fromJson(Map<String, dynamic> json) {
    if(json["customerId"] is int) {
      customerId = json["customerId"];
    }
    if(json["customerName"] is String) {
      customerName = json["customerName"];
    }
    if(json["age"] is int) {
      age = json["age"];
    }
    if(json["email"] is String) {
      email = json["email"];
    }
    if(json["status"] is bool) {
      status = json["status"];
    }
    if(json["tickets"] is List) {
      tickets = json["tickets"] ?? [];
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["customerId"] = customerId;
    _data["customerName"] = customerName;
    _data["age"] = age;
    _data["email"] = email;
    _data["status"] = status;
    if(tickets != null) {
      _data["tickets"] = tickets;
    }
    return _data;
  }
}