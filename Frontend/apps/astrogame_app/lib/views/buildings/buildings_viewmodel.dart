import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/providers/buildings_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingsViewModel extends BaseViewModel {
  BuildingsProvider _buildingsProvider;

  BuildingsViewModel(
    this._buildingsProvider,
  );

  List<Building> get buildings => _buildingsProvider.getBuildings();
}
