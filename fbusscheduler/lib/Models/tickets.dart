
class Ticket {
  int? ticketId;
  String? customerName;
  String? departurTime;
  String? arrivalTime;
  String? comment;
  int? status;
  int? customerId;
  dynamic customer;
  List<dynamic>? ticketStations;

  Ticket({this.ticketId, this.customerName, this.departurTime, this.arrivalTime, this.comment, this.status, this.customerId, this.customer, this.ticketStations});

  Ticket.fromJson(Map<String, dynamic> json) {
    if(json["ticketId"] is int) {
      ticketId = json["ticketId"];
    }
    if(json["customerName"] is String) {
      customerName = json["customerName"];
    }
    if(json["departurTime"] is String) {
      departurTime = json["departurTime"];
    }
    if(json["arrivalTime"] is String) {
      arrivalTime = json["arrivalTime"];
    }
    if(json["comment"] is String) {
      comment = json["comment"];
    }
    if(json["status"] is int) {
      status = json["status"];
    }
    if(json["customerId"] is int) {
      customerId = json["customerId"];
    }
    customer = json["customer"];
    if(json["ticketStations"] is List) {
      ticketStations = json["ticketStations"] ?? [];
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["ticketId"] = ticketId;
    _data["customerName"] = customerName;
    _data["departurTime"] = departurTime;
    _data["arrivalTime"] = arrivalTime;
    _data["comment"] = comment;
    _data["status"] = status;
    _data["customerId"] = customerId;
    _data["customer"] = customer;
    if(ticketStations != null) {
      _data["ticketStations"] = ticketStations;
    }
    return _data;
  }
}