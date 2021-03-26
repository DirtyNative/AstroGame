import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/enums/species_type.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'species.g.dart';

@GuidConverter()
@JsonSerializable()
class Species {
  Guid id;
  SpeciesType speciesType;
  String assetName;

  Species();

  factory Species.fromJson(Map<String, dynamic> json) =>
      _$SpeciesFromJson(json);
  Map<String, dynamic> toJson() => _$SpeciesToJson(this);
}
