import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/enums/planet_type.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:astrogame_app/models/stellar/base_types/colonizable_stellar_object.dart';
import 'package:json_annotation/json_annotation.dart';

part 'planet.g.dart';

@GuidConverter()
@JsonSerializable()
class Planet extends ColonizableStellarObject {
  @JsonKey()
  PlanetType planetType;

  @JsonKey()
  double scale;

  @JsonKey()
  double axialTilt;

  @JsonKey()
  List<StellarObjectResource> resources;

  @JsonKey()
  bool hasHabitableAtmosphere;

  Planet();

  factory Planet.fromJson(Map<String, dynamic> json) => _$PlanetFromJson(json);
  Map<String, dynamic> toJson() => _$PlanetToJson(this);
}
