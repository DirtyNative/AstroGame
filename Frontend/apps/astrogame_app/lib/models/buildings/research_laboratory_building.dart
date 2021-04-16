import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:json_annotation/json_annotation.dart';
import 'building.dart';
import 'package:astrogame_app/models/buildings/building_cost.dart';
import 'package:astrogame_app/models/buildings/input_resource.dart';
import 'package:astrogame_app/models/buildings/output_resource.dart';
import 'package:astrogame_app/models/enums/stellar_object_type.dart';

part 'research_laboratory_building.g.dart';

@GuidConverter()
@JsonSerializable()
class ResearchLaboratoryBuilding extends Building {
  ResearchLaboratoryBuilding();

  factory ResearchLaboratoryBuilding.fromJson(Map<String, dynamic> json) => _$ResearchLaboratoryBuildingFromJson(json);
  Map<String, dynamic> toJson() => _$ResearchLaboratoryBuildingToJson(this);
}
