import 'package:astrogame_app/communications/repositories/stellar_object_repository.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/providers/selected_stellar_object_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ColonyViewModel extends BaseViewModel {
  SelectedStellarObjectProvider _selectedStellarObjectProvider;
  StellarObjectRepository _stellarObjectRepository;

  ColonizedStellarObject colonizedStellarObject;

  ColonyViewModel(
    this._selectedStellarObjectProvider,
    this._stellarObjectRepository,
    @factoryParam this.colonizedStellarObject,
  );

  bool get isSelected =>
      _selectedStellarObjectProvider.getSelectedStellarObject() ==
      colonizedStellarObject;

  Future<ImageProvider> getStellarObjectImageAsync(Guid stellarObjectId) async {
    var response = await _stellarObjectRepository.getImageAsync(
      stellarObjectId: stellarObjectId,
    );

    if (response.hasError) {
      throw Exception('Failed to load stellar object image $stellarObjectId');
    }

    return response.data;
  }

  Future<StellarObject> fetchStellarObject(Guid id) async {
    var response = await _stellarObjectRepository.getAsync(id);

    if (response.hasError) {
      throw new Exception(response.error);
    }

    return response.data;
  }
}
