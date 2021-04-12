import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/events/buildings/building_construction_started_event.dart';
import 'package:astrogame_app/executers/executer_result.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:astrogame_app/services/event_service.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';

@injectable
class BuildBuildingExecuter {
  EventService _eventService;

  BuildingRepository _buildingRepository;
  BuildingChainProvider _buildingChainProvider;

  DialogHelper _dialogHelper;

  BuildBuildingExecuter(
    this._eventService,
    this._dialogHelper,
    this._buildingRepository,
    this._buildingChainProvider,
  );

  Future<ExecuterResult> buildBuildingAsync(
    Guid buildingId,
  ) async {
    _dialogHelper.showLoadingIndicator();

    var response = await _buildingRepository.buildAsync(buildingId);

    // If there happened an error
    if (response.hasError) {
      // TODO: show error dialog;
      _dialogHelper.dismissDialog();
      return ExecuterResult.error();
    }

    await _buildingChainProvider.updateAsync();
    // TODO: await _storedResourceProvider.updateAsync();

    // Raise an event so that the ui can update
    _eventService.fire(new BuildingConstructionStartetEvent());

    _dialogHelper.dismissDialog();
    return ExecuterResult.success();
  }
}
