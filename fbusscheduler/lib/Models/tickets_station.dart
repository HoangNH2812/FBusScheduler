
class TicketsStation {
  int? ticketId;
  int? stationId;
  String? checkInTime;
  String? checkOutTime;
  dynamic station;
  dynamic ticket;

  TicketsStation({this.ticketId, this.stationId, this.checkInTime, this.checkOutTime, this.station, this.ticket});

  TicketsStation.fromJson(Map<String, dynamic> json) {
    if(json["ticketId"] is int) {
      ticketId = json["ticketId"];
    }
    if(json["stationId"] is int) {
      stationId = json["stationId"];
    }
    if(json["checkInTime"] is String) {
      checkInTime = json["checkInTime"];
    }
    if(json["checkOutTime"] is String) {
      checkOutTime = json["checkOutTime"];
    }
    station = json["station"];
    ticket = json["ticket"];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> _data = <String, dynamic>{};
    _data["ticketId"] = ticketId;
    _data["stationId"] = stationId;
    _data["checkInTime"] = checkInTime;
    _data["checkOutTime"] = checkOutTime;
    _data["station"] = station;
    _data["ticket"] = ticket;
    return _data;
  }
}