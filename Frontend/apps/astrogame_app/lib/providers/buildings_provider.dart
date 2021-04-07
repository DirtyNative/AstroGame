import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:injectable/injectable.dart';

@singleton
class BuildingsProvider {
  BuildingRepository _buildingRepository;
  List<Building> _buildings;

  BuildingsProvider(this._buildingRepository);

  Future<List<Building>> get() async => _buildings ?? await _fetchAsync();
  void set(List<Building> val) => _buildings = val;

  Future<List<Building>> _fetchAsync() async {
    var buildingsResponse = await _buildingRepository.getAllAsync();

    if (buildingsResponse.hasError) {
      // TODO: show error dialog
    }

    set(buildingsResponse.data);
    return buildingsResponse.data;
  }
}
