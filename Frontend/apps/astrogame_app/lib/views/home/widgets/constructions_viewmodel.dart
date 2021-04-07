import 'dart:async';

import 'package:astrogame_app/communications/repositories/stellar_object_repository.dart';
import 'package:astrogame_app/models/buildings/building_chain.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class ConstructionsViewModel extends BaseViewModel {
  BuildingChainProvider _buildingChainProvider;
  StellarObjectRepository _stellarObjectRepository;

  Timer _timer;

  ConstructionsViewModel(
    this._buildingChainProvider,
    this._stellarObjectRepository,
  ) {
    _timer = Timer.periodic(Duration(seconds: 1), (timer) {
      notifyListeners();
    });
  }

  Future<BuildingChain> fetchBuildingChain() async {
    return await _buildingChainProvider.get();
  }

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

  @override
  void dispose() {
    _timer.cancel();
    super.dispose();
  }
}
