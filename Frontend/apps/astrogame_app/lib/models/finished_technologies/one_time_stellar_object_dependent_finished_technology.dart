import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/finished_technologies/one_time_finished_technology.dart';
import 'stellar_object_dependent_finished_technology.dart';
import 'package:json_annotation/json_annotation.dart';

part 'one_time_stellar_object_dependent_finished_technology.g.dart';

@JsonSerializable()
@GuidConverter()
class OneTimeStellarObjectDependentFinishedTechnology
    extends StellarObjectDependentFinishedTechnology
    with OneTimeFinishedTechnology {
  OneTimeStellarObjectDependentFinishedTechnology();

  factory OneTimeStellarObjectDependentFinishedTechnology.fromJson(
          Map<String, dynamic> json) =>
      _$OneTimeStellarObjectDependentFinishedTechnologyFromJson(json);
  Map<String, dynamic> toJson() =>
      _$OneTimeStellarObjectDependentFinishedTechnologyToJson(this);
}
