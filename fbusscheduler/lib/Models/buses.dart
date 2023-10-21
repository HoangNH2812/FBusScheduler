
class Bus {
  int? busId;
  int? busNumber;
  String? currentLocation;
  bool? busStatus;
  int? totalSeats;
  bool? status;
  List<dynamic>? trips;

  Bus({this.busId, this.busNumber, this.currentLocation, this.busStatus, this.totalSeats, this.status, this.trips});

  Bus.fromJson(Map<String, dynamic> json) {
    if(json["busId"] is int) {
      busId = json["busId"];
    }
    if(json["busNumber"] is int) {
      busNumber = json["busNumber"];
    }
    if(json["currentLocation"] is String) {
      currentLocation = json["currentLocation"];
    }
    if(json["busStatus"] is bool) {
      busStatus = json["busStatus"];
    }
    if(json["totalSeats"] is int) {
      totalSeats = json["totalSeats"];
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
    _data["busId"] = busId;
    _data["busNumber"] = busNumber;
    _data["currentLocation"] = currentLocation;
    _data["busStatus"] = busStatus;
    _data["totalSeats"] = totalSeats;
    _data["status"] = status;
    if(trips != null) {
      _data["trips"] = trips;
    }
    return _data;
  }
}