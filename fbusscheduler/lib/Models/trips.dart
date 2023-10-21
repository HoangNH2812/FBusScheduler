
class Trip {
  int? tripId;
  String? routeName;
  int? maxTicket;
  int? routeId;
  int? busId;
  int? driverId;
  bool? status;
  dynamic bus;
  dynamic detailTrip;
  dynamic driver;
  dynamic route;

  Trip({this.tripId, this.routeName, this.maxTicket, this.routeId, this.busId, this.driverId, this.status, this.bus, this.detailTrip, this.driver, this.route});

  Trip.fromJson(Map<String, dynamic> json) {
    if(json["tripId"] is int) {
      tripId = json["tripId"];
    }
    if(json["routeName"] is String) {
      routeName = json["routeName"];
    }
    if(json["maxTicket"] is int) {
      maxTicket = json["maxTicket"];
    }
    if(json["routeId"] is int) {
      routeId = json["routeId"];
    }
    if(json["busId"] is int) {
      busId = json["busId"];
    }
    if(json["driverId"] is int) {
      driverId = json["driverId"];
    }
    if(json["status"] is bool) {
      status = json["status"];
    }
    bus = json["bus"];
    detailTrip = json["detailTrip"];
    driver = json["driver"];
    route = json["route"];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["tripId"] = tripId;
    _data["routeName"] = routeName;
    _data["maxTicket"] = maxTicket;
    _data["routeId"] = routeId;
    _data["busId"] = busId;
    _data["driverId"] = driverId;
    _data["status"] = status;
    _data["bus"] = bus;
    _data["detailTrip"] = detailTrip;
    _data["driver"] = driver;
    _data["route"] = route;
    return _data;
  }
}