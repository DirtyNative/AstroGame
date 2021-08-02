import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';
import 'package:astrogame_app/models/technologies/technology_upgrade.dart';

import 'package:json_annotation/json_annotation.dart';

part 'stellar_object_dependent_technology_upgrade.g.dart';

@GuidConverter()
@JsonSerializable()
class StellarObjectDependentTechnologyUpgrade extends TechnologyUpgrade {
  late Guid stellarObjectId;

  StellarObjectDependentTechnologyUpgrade();

  factory StellarObjectDependentTechnologyUpgrade.fromJson(
          Map<String, dynamic> json) =>
      _$StellarObjectDependentTechnologyUpgradeFromJson(json);
  Map<String, dynamic> toJson() =>
      _$StellarObjectDependentTechnologyUpgradeToJson(this);
}
