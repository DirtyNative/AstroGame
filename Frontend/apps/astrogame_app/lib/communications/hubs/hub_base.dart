import 'package:signalr_core/signalr_core.dart';

abstract class HubBase {
  String url;
  HubConnection connection;

  HubBase();

  Future connectAsync();
}
