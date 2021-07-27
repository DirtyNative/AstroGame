import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:astrogame_app/providers/solar_systems_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class GalaxyViewModel extends FutureViewModel {
  SolarSystemsProvider _solarSystemsProvider;

  GalaxyViewModel(this._solarSystemsProvider);

  late List<SolarSystem> _solarSystems;
  List<SolarSystem> get solarSystems => _solarSystems;
  set solarSystems(List<SolarSystem> val) {
    _solarSystems = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    solarSystems = await _fetchSolarSystems();
  }

  Future<List<SolarSystem>> _fetchSolarSystems() async {
    return await _solarSystemsProvider.get(-1, 1, -1, 1);
  }
}
