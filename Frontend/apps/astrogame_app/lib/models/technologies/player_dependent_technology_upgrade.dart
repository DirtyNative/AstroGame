import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';

import 'package:json_annotation/json_annotation.dart';

part 'player_dependent_technology_upgrade.g.dart';

@GuidConverter()
@JsonSerializable()
class PlayerDependentTechnologyUpgrade extends TechnologyUpgrade {
  late Guid playerId;

  PlayerDependentTechnologyUpgrade();

  factory PlayerDependentTechnologyUpgrade.fromJson(
          Map<String, dynamic> json) =>
      _$PlayerDependentTechnologyUpgradeFromJson(json);
  Map<String, dynamic> toJson() =>
      _$PlayerDependentTechnologyUpgradeToJson(this);
}
