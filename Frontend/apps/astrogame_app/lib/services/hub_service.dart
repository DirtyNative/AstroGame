import 'package:astrogame_app/communications/hubs/building_hub.dart';
import 'package:injectable/injectable.dart';

@injectable
class HubService {
  BuildingHub _buildingHub;

  HubService(this._buildingHub);

  Future connectAsync() async {
    await _buildingHub.connectAsync();
  }
}
