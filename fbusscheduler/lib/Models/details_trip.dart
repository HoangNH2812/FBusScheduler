
class DetailTrip {
  int? tripId;
  int? stationId;
  String? arrivalTime;
  dynamic station;
  dynamic trip;

  DetailTrip({this.tripId, this.stationId, this.arrivalTime, this.station, this.trip});

  DetailTrip.fromJson(Map<String, dynamic> json) {
    if(json["tripId"] is int) {
      tripId = json["tripId"];
    }
    if(json["stationId"] is int) {
      stationId = json["stationId"];
    }
    if(json["arrivalTime"] is String) {
      arrivalTime = json["arrivalTime"];
    }
    station = json["station"];
    trip = json["trip"];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["tripId"] = tripId;
    _data["stationId"] = stationId;
    _data["arrivalTime"] = arrivalTime;
    _data["station"] = station;
    _data["trip"] = trip;
    return _data;
  }
}