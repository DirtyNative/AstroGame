import 'package:astrogame_app/communications/hubs/technology_hub.dart';
import 'package:injectable/injectable.dart';

@injectable
class HubService {
  TechnologyHub _buildingHub;

  HubService(this._buildingHub);

  Future connectAsync() async {
    await _buildingHub.connectAsync();
  }
}
