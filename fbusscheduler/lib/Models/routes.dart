
class Routes {
  int? routeId;
  String? startingLocation;
  String? destination;
  String? distance;
  String? routeName;
  bool? status;
  List<dynamic>? routations;
  List<dynamic>? trips;

  Routes({this.routeId, this.startingLocation, this.destination, this.distance, this.routeName, this.status, this.routations, this.trips});

  Routes.fromJson(Map<String, dynamic> json) {
    if(json["routeId"] is int) {
      routeId = json["routeId"];
    }
    if(json["startingLocation"] is String) {
      startingLocation = json["startingLocation"];
    }
    if(json["destination"] is String) {
      destination = json["destination"];
    }
    if(json["distance"] is String) {
      distance = json["distance"];
    }
    if(json["routeName"] is String) {
      routeName = json["routeName"];
    }
    if(json["status"] is bool) {
      status = json["status"];
    }
    if(json["routations"] is List) {
      routations = json["routations"] ?? [];
    }
    if(json["trips"] is List) {
      trips = json["trips"] ?? [];
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["routeId"] = routeId;
    _data["startingLocation"] = startingLocation;
    _data["destination"] = destination;
    _data["distance"] = distance;
    _data["routeName"] = routeName;
    _data["status"] = status;
    if(routations != null) {
      _data["routations"] = routations;
    }
    if(trips != null) {
      _data["trips"] = trips;
    }
    return _data;
  }
}