import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/executers/executer_result.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';

@injectable
class BuildBuildingExecuter {
  BuildingRepository _buildingRepository;

  DialogHelper _dialogHelper;

  BuildBuildingExecuter(
    this._dialogHelper,
    this._buildingRepository,
  );

  Future<ExecuterResult> buildBuildingAsync(
    Guid buildingId,
  ) async {
    _dialogHelper.showLoadingIndicator();

    var response = await _buildingRepository.buildAsync(buildingId);

    // If there happened an error
    if (response.hasError) {
      // TODO: show error dialog;
      return ExecuterResult.error();
    }

    _dialogHelper.dismissDialog();

    // TODO: Raise event that the resources have been updated and that a building is in queue

    return ExecuterResult.success();
  }
}
