import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/models/buildings/building.dart';
import 'package:astrogame_app/providers/buildings_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class BuildingsViewModel extends BaseViewModel {
  BuildingsProvider _buildingsProvider;
  BuildingRepository _buildingRepository;

  BuildingsViewModel(
    this._buildingsProvider,
    this._buildingRepository,
  );

  List<Building> get buildings => _buildingsProvider.getBuildings();

  Future<ImageProvider> getImageAsync(Guid buildingId) async {
    var response =
        await _buildingRepository.getImageAsync(buildingId: buildingId);

    if (response.hasError) {
      throw Exception('Failed to load building image $buildingId');
    }

    return response.data;
  }
}
