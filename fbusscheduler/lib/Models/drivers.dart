
class Driver {
  int? driverId;
  String? driverName;
  String? driverPhone;
  bool? license;
  bool? driverStatus;
  String? email;
  bool? status;
  List<dynamic>? trips;

  Driver({this.driverId, this.driverName, this.driverPhone, this.license, this.driverStatus, this.email, this.status, this.trips});

  Driver.fromJson(Map<String, dynamic> json) {
    if(json["driverId"] is int) {
      driverId = json["driverId"];
    }
    if(json["driverName"] is String) {
      driverName = json["driverName"];
    }
    if(json["driverPhone"] is String) {
      driverPhone = json["driverPhone"];
    }
    if(json["license"] is bool) {
      license = json["license"];
    }
    if(json["driverStatus"] is bool) {
      driverStatus = json["driverStatus"];
    }
    if(json["email"] is String) {
      email = json["email"];
    }
    if(json["status"] is bool) {
      status = json["status"];
    }
    if(json["trips"] is List) {
      trips = json["trips"] ?? [];
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["driverId"] = driverId;
    _data["driverName"] = driverName;
    _data["driverPhone"] = driverPhone;
    _data["license"] = license;
    _data["driverStatus"] = driverStatus;
    _data["email"] = email;
    _data["status"] = status;
    if(trips != null) {
      _data["trips"] = trips;
    }
    return _data;
  }
}