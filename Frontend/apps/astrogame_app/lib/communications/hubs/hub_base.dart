import 'package:signalr_core/signalr_core.dart';

abstract class HubBase {
  String url;
  HubConnection? connection;

  HubBase(this.url);

  Future connectAsync();
}
