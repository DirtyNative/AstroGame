import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'stellar_object_dependent_finished_technology.g.dart';

@GuidConverter()
@JsonSerializable()
class StellarObjectDependentFinishedTechnology extends FinishedTechnology {
  @JsonKey()
  Guid colonizedStellarObjectId;

  StellarObjectDependentFinishedTechnology();

  factory StellarObjectDependentFinishedTechnology.fromJson(
          Map<String, dynamic> json) =>
      _$StellarObjectDependentFinishedTechnologyFromJson(json);
  Map<String, dynamic> toJson() =>
      _$StellarObjectDependentFinishedTechnologyToJson(this);
}
