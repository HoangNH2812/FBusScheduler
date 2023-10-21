
class Routation {
  int? routeId;
  int? stationId;
  int? stationIndex;
  int? stationMode;
  String? defaultDuration;
  dynamic route;
  dynamic station;

  Routation({this.routeId, this.stationId, this.stationIndex, this.stationMode, this.defaultDuration, this.route, this.station});

  Routation.fromJson(Map<String, dynamic> json) {
    if(json["routeId"] is int) {
      routeId = json["routeId"];
    }
    if(json["stationId"] is int) {
      stationId = json["stationId"];
    }
    if(json["stationIndex"] is int) {
      stationIndex = json["stationIndex"];
    }
    if(json["stationMode"] is int) {
      stationMode = json["stationMode"];
    }
    if(json["defaultDuration"] is String) {
      defaultDuration = json["defaultDuration"];
    }
    route = json["route"];
    station = json["station"];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["routeId"] = routeId;
    _data["stationId"] = stationId;
    _data["stationIndex"] = stationIndex;
    _data["stationMode"] = stationMode;
    _data["defaultDuration"] = defaultDuration;
    _data["route"] = route;
    _data["station"] = station;
    return _data;
  }
}