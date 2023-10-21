
class Station {
  int? stationId;
  String? stationName;
  String? location;
  bool? stationStatus;
  List<dynamic>? detailTrips;
  List<dynamic>? routations;
  List<dynamic>? ticketStations;

  Station({this.stationId, this.stationName, this.location, this.stationStatus, this.detailTrips, this.routations, this.ticketStations});

  Station.fromJson(Map<String, dynamic> json) {
    if(json["stationId"] is int) {
      stationId = json["stationId"];
    }
    if(json["stationName"] is String) {
      stationName = json["stationName"];
    }
    if(json["location"] is String) {
      location = json["location"];
    }
    if(json["stationStatus"] is bool) {
      stationStatus = json["stationStatus"];
    }
    if(json["detailTrips"] is List) {
      detailTrips = json["detailTrips"] ?? [];
    }
    if(json["routations"] is List) {
      routations = json["routations"] ?? [];
    }
    if(json["ticketStations"] is List) {
      ticketStations = json["ticketStations"] ?? [];
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["stationId"] = stationId;
    _data["stationName"] = stationName;
    _data["location"] = location;
    _data["stationStatus"] = stationStatus;
    if(detailTrips != null) {
      _data["detailTrips"] = detailTrips;
    }
    if(routations != null) {
      _data["routations"] = routations;
    }
    if(ticketStations != null) {
      _data["ticketStations"] = ticketStations;
    }
    return _data;
  }
}