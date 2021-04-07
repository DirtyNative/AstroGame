import 'package:astrogame_app/models/buildings/building_construction.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/providers/buildings_provider.dart';
import 'package:astrogame_app/providers/selected_colonized_stellar_object_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingsViewModel extends BaseViewModel {
  BuildingsProvider buildingsProvider;
  BuildingChainProvider _buildingChainProvider;
  SelectedColonizedStellarObjectProvider
      _selectedColonizedStellarObjectProvider;

  BuildingsViewModel(
    this.buildingsProvider,
    this._buildingChainProvider,
    this._selectedColonizedStellarObjectProvider,
  );

  Future<BuildingConstruction> fetchActiveConstruction() async {
    return _buildingChainProvider.getByStellarObject(
        _selectedColonizedStellarObjectProvider
            .getSelectedObject()
            .stellarObjectId);
  }
}
