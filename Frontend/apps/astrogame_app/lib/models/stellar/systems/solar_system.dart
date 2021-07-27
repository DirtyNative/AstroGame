import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/communications/converters/stellar_object_converter.dart';
import 'package:astrogame_app/communications/converters/stellar_system_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/common/vector_3.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:json_annotation/json_annotation.dart';

part 'solar_system.g.dart';

@GuidConverter()
@StellarObjectConverter()
@StellarSystemConverter()
@JsonSerializable()
class SolarSystem extends StellarSystem {
  @JsonKey()
  late String name;

  @JsonKey()
  late Coordinates coordinates;

  @JsonKey()
  late bool isGenerated;

  late Vector3 position;

  SolarSystem();

  factory SolarSystem.fromJson(Map<String, dynamic> json) =>
      _$SolarSystemFromJson(json);
  Map<String, dynamic> toJson() => _$SolarSystemToJson(this);
}
