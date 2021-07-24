import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/finished_technologies/levelable_finished_technology.dart';
import 'stellar_object_dependent_finished_technology.dart';
import 'package:json_annotation/json_annotation.dart';

part 'levelable_stellar_object_dependent_finished_technology.g.dart';

@JsonSerializable()
@GuidConverter()
class LevelableStellarObjectDependentFinishedTechnology
    extends StellarObjectDependentFinishedTechnology
    with LevelableFinishedTechnology {
  LevelableStellarObjectDependentFinishedTechnology();

  factory LevelableStellarObjectDependentFinishedTechnology.fromJson(
          Map<String, dynamic> json) =>
      _$LevelableStellarObjectDependentFinishedTechnologyFromJson(json);
  Map<String, dynamic> toJson() =>
      _$LevelableStellarObjectDependentFinishedTechnologyToJson(this);
}
