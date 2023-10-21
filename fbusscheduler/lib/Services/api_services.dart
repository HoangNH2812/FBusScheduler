import 'package:fbusscheduler/Services/api_urls.dart';
import '../Models/buses.dart';
import 'package:http/http.dart' as http;
import 'dart:convert' as json;
import '../Models/customers.dart';
import '../Models/routes.dart';
import '../Models/tickets.dart';

class ApiBusService {
  // Future<List<Bus>> fetchBus() {
  //   return http
  //       .get(api_urls().API_BUS_LIST)
  //       .then((http.Response response) {
  //     final String jsonBody = response.body;
  //     final int statusCode = response.statusCode;
  //
  //     if(statusCode != 200 || jsonBody == null){
  //       print(response.reasonPhrase);
  //       throw new Exception("Lỗi load api");
  //     }
  //
  //     final JsonDecoder _decoder = new JsonDecoder();
  //     final busListContainer = _decoder.convert(jsonBody);
  //     final List busList = busListContainer['results'];
  //     return busList.map((contactRaw) => new Bus.fromJson(contactRaw)).toList();
  //   });
  // }
  List<Bus> parseBus(String responseBody) {
    final parsed = json.jsonDecode(responseBody).cast<Map<String, dynamic>>();
    return parsed.map<Bus>((json) => Bus.fromJson(json)).toList();
  }

  Future<List<Bus>> fetchBus() async {
    final response = await http.get(ApiUrls().API_BUSES_LIST);
    if (response.statusCode == 200) {
      return parseBus(response.body);
    } else {
      throw Exception('Unable to fetch products from the REST API');
    }
  }
}

class ApiCustomerService {
  List<Customer> parseCustomer(String responseBody) {
    final parsed = json.jsonDecode(responseBody).cast<Map<String, dynamic>>();
    return parsed.map<Customer>((json) => Customer.fromJson(json)).toList();
  }

  Future<List<Customer>> fetchCustomer() async {
    final response = await http.get(ApiUrls().API_CUSTOMERS_LIST);
    if (response.statusCode == 200) {
      return parseCustomer(response.body);
    } else {
      throw Exception('Unable to fetch products from the REST API');
    }
  }
}

class ApiTicketService {
  List<Ticket> parseTicket(String responseBody) {
    final parsed = json.jsonDecode(responseBody).cast<Map<String, dynamic>>();
    return parsed.map<Ticket>((json) => Ticket.fromJson(json)).toList();
  }

  Future<List<Ticket>> fetchTicket() async {
    final response = await http.get(ApiUrls().API_TICKETS_LIST);
    if (response.statusCode == 200) {
      return parseTicket(response.body);
    } else {
      throw Exception('Unable to fetch products from the REST API');
    }
  }
}

class ApiRoutesService {
  List<Routes> parseRoutes(String responseBody) {
    final parsed = json.jsonDecode(responseBody).cast<Map<String, dynamic>>();
    return parsed.map<Routes>((json) => Routes.fromJson(json)).toList();
  }

  Future<List<Routes>> fetchRoutes() async {
    final response = await http.get(ApiUrls().API_ROUTES_LIST);
    if (response.statusCode == 200) {
      return parseRoutes(response.body);
    } else {
      throw Exception('Unable to fetch products from the REST API');
    }
  }
}
