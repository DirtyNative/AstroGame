import 'package:astrogame_app/communications/repositories/building_repository.dart';
import 'package:astrogame_app/executers/executer_result.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/providers/building_chain_provider.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:injectable/injectable.dart';

@injectable
class BuildBuildingExecuter {
  BuildingRepository _buildingRepository;
  BuildingChainProvider _buildingChainProvider;

  DialogHelper _dialogHelper;

  BuildBuildingExecuter(
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

    _dialogHelper.dismissDialog();
    return ExecuterResult.success();
  }
}
