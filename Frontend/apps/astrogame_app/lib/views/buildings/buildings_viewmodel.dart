import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/providers/buildings_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingsViewModel extends FutureViewModel {
  BuildingsProvider buildingsProvider;

  List<Building> _buildings;
  List<Building> get buildings => _buildings;
  set buildings(List<Building> val) {
    _buildings = val;
    notifyListeners();
  }

  BuildingsViewModel(
    this.buildingsProvider,
  );

  Future<List<Building>> fetchBuildingsAsync() async {
    return await buildingsProvider.get();
  }

  Future updateAsync() async {
    buildings = await fetchBuildingsAsync();
  }

  @override
  Future futureToRun() => updateAsync();
}
